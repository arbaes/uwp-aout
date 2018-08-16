﻿using DataAccess;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

using GalaSoft.MvvmLight.Views;
using Model;
using smartchUWP.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smartchUWP.ViewModel
{
    public class MembresModelView : SmartchViewModelBase
    {
        public RelayCommand CmdNavigateAddMembre { get; private set; }

        
        private ObservableCollection<User> _users = null;
        public MembresModelView(INavigationService navigationService) : base(navigationService)
        {
            
            if (IsInDesignMode)
            {
                _users = new ObservableCollection<User> { new User() { Name = "Nom1" }, new User() { Name = "Nm2" } };
            }
            else
            {
                MessengerInstance.Register<NotificationMessage>(this, MessageReceiver);
                CmdNavigateAddMembre = new RelayCommand(NavigateToAddMembre);
                SetUsers();
            }
        }
        private void NavigateToAddMembre()
        {
            _navigationService.NavigateTo("AddMembre");
        }
        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
                if (_users == value)
                {
                    return;
                }
                _users = value;
                RaisePropertyChanged("Users");
            }
        }
 
        public async Task SetUsers()
        {
            var service = new UsersServices();
            try
            {
                List<User> users = await service.GetUsers();
                Users = new ObservableCollection<User>(users);
            }
            catch(Exception e)
            {
                SetGeneralErrorMessage(e);
            }
            
                
            
        }
        private async void MessageReceiver(NotificationMessage message)
        {
            switch (message.VariableType)
            {
                case NotificationMessageType.ListUser:
                    await SetUsers();

                    break;
            }
        }
    }
}
