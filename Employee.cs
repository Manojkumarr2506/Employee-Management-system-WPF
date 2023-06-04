using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnpropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public string path { get; set; } = @"C:\Users\manoj\OneDrive\Desktop\employee.txt";

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value;  }
            
         }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value;  }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }


    }
}
