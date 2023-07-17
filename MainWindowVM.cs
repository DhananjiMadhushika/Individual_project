using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Desktop01.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Desktop01
{
    public  partial class MainWindowVM : ObservableObject
    {
        [ObservableProperty]
        public  ObservableCollection<User> users;
        [ObservableProperty]
        public User selectedUser=null;


        [RelayCommand]
        public void Close1()
        {
            Application.Current.Shutdown();
        }




        [RelayCommand]
        public void messeag()
        {

            MessageBox.Show($"{selectedUser.FirstName} GPA value must be between 0 and 4.", "Error");
        }

        [RelayCommand]
        public void AddStudent()
        {
            var vm = new AddUserVM();
            vm.title = "Add Student";
            AddUserWindow window = new AddUserWindow(vm);
            window.ShowDialog();

            if (vm.Student.FirstName != null)
            {
                users.Add(vm.Student);
            }
        }

        [RelayCommand]
        public void Delete()
        {
            if (selectedUser != null)
            {
                string name = selectedUser.FirstName;
                users.Remove(selectedUser);
                MessageBox.Show($"{name} is deleted successfuly!");
                
            }
            else
            {
                MessageBox.Show("Plese select the student to be deleted!", "Error");


            }
        }
        [RelayCommand]
        public void ExecuteEditStudentCommand()
        {
            if (selectedUser != null)
            {
                var vm = new AddUserVM(selectedUser);
                vm.title = "Edit Student";
                var window = new AddUserWindow(vm);

                window.ShowDialog();


                int index = users.IndexOf(selectedUser);
                users.RemoveAt(index);
                users.Insert(index, vm.Student);



            }
            else
            {
                MessageBox.Show("Please select the student to edit!", "Error");
            }
        }

     


        public  MainWindowVM()
        {
            
            users = new ObservableCollection<User>();

            BitmapImage image1 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(25, "Hiruni", "Kavindi", "27/05/1999",image1, 3.2));

            BitmapImage image2 = new BitmapImage(new Uri("/Model/Images/7.png", UriKind.Relative));
            users.Add(new User(24, "Dinethma", "Vidumi", "10/04/1999",image2, 2.5));

            BitmapImage image3 = new BitmapImage(new Uri("/Model/Images/10.png", UriKind.Relative));
            users.Add(new User(23, "Yasitha", "Dilruksha", "12/03/2000",image3, 3.5));

            BitmapImage image4 = new BitmapImage(new Uri("/Model/Images/4.png", UriKind.Relative));
            users.Add(new User(23, "Dhananji", "Madhushika", "03/03/1999",image4, 3.0));

            BitmapImage image5 = new BitmapImage(new Uri("/Model/Images/9.png", UriKind.Relative));
            users.Add(new User(23, "Amandi", "Devindi", "02/01/2000", image4, 2.8));

            BitmapImage image6 = new BitmapImage(new Uri("/Model/Images/2.png", UriKind.Relative));
            users.Add(new User(23, "Kavindu", "Ransara", "20/11/1999", image4, 2.2));



        }
    }
}
