using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using System.Collections.ObjectModel;
using WpfAppemployee.Commands;

namespace WpfApp1.ModelView
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        EmployeeService es;
        #region onpropertychange
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region constructor
        public EmployeeViewModel()
        {
            es=new EmployeeService();
            Load();
            Curremp=new Employee();
            savecomm = new relay(save);
            searchCommmand=new relay(search);
            updateCommand = new relay(update);
            deleteCommand= new relay(delete);
        }
        #endregion

        #region Elist to FrontEnd
        private ObservableCollection<Employee> employeesList;
        public ObservableCollection<Employee> Elist 
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged(nameof(Elist)); }
        }
        #endregion

        #region load
        private void Load()
        {
            Elist=new ObservableCollection<Employee>( es.GetEmployees()); 
        }
        #endregion

        #region current Employee
        private Employee curremp;

        public Employee Curremp
        {
            get { return curremp; }
            set { curremp = value; OnPropertyChanged(nameof(curremp));  }
        }



        #endregion

        #region message to display

        private string mess;

        public string Mess
        {
            get { return mess; }
            set { mess = value; OnPropertyChanged("Mess"); }
        }
        #endregion

        #region insert

        private relay savecomm;

        public relay Savecomm
        {
            get { return savecomm; }

        }
        public void save()
        {
            try
            {
                var Issaved = es.AddEmployee(Curremp);
                Load();
                if (Issaved)
                {
                    Mess = "Employee Added Sucessfully";
                    Curremp = new Employee();
                }
                else
                    Mess = "Nope,not added";
               
            }
            catch (Exception ex)
            {

                Mess=ex.Message;
            }
        }
        #endregion

        #region search
        private relay searchCommmand;

        public relay SearchCommand
        {
            get { return searchCommmand; }
            
        }

        public void search()
        {
            try
            {
                var objemp = es.searchEmployee(curremp.Id);
                if (objemp != null)
                {
                    Curremp.Age = objemp.Age;
                    Curremp.Name = objemp.Name;
                    Curremp = objemp;
                }
                else
                { Mess = "Employee Not found"; }

            }
            catch (Exception e1)
            {

                Mess = e1.Message;
            }
        }
        #endregion

        #region update

        private relay updateCommand;

        public relay UpdateCommand
        {
            get { return updateCommand; }
            set { updateCommand = value; }
        }

        public void update()
        {
            try
            {
                var isUpdate = es.UpdateEmployee(Curremp);
                if (isUpdate)
                {
                    Mess = "Employee updated successfully";
                    Load();
                }
                else
                    Mess = "Updation,Failed...!";
            }
            catch (Exception m1)
            {

                Mess=(m1.Message);  
            }
        }

        #endregion

        #region delete
        private relay deleteCommand;

        public relay DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }

        public void delete()
        {
            try
            {
                var isDeleted = es.RemoveEmployee(Curremp.Id);
                if (isDeleted)
                {
                    Mess = "Employee deleted successfully";
                    Load();
                }
                else Mess = "Delete operation Unsucessfull...!";
            }
            catch (Exception d1)
            {

                Mess = d1.Message;
            }
        }

        #endregion

        #region clear
        private relay clearCommand;
        public relay ClearCommand
        {
            get { return clearCommand; }
        }
        public void clear()
        {
            if(Curremp!=null)
            {
                Curremp.Age=0;
                Curremp.Id=0;
                Load();
            }
        }
        #endregion

    }
}
