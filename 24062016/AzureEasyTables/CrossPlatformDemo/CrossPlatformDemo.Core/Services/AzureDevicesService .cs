using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using CrossPlatformDemo.Core.Models;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;

namespace CrossPlatformDemo.Core.Services
{
    public class AzureDevicesService
    {
        private IMobileServiceSyncTable<Device> _deviceTable;


        public MobileServiceClient DevicesMobileService { get; set; }

        public async Task InitializeAsync()
        {
            DevicesMobileService = new MobileServiceClient("https://XamarinTechSummitDemo.azurewebsites.net");

            const string path = "devices.db";

            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<Device>();
            await DevicesMobileService.SyncContext.InitializeAsync(store, new MobileServiceSyncHandler());

            _deviceTable = DevicesMobileService.GetSyncTable<Device>();

        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            return await _deviceTable.OrderBy(c => c.DeviceName).ToListAsync();
        }

        public async Task SynchronizeAsync()
        {
            try
            {
                await _deviceTable.PullAsync("allDevices", _deviceTable.CreateQuery());
                await DevicesMobileService.SyncContext.PushAsync();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
