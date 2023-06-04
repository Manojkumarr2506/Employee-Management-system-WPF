using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;
using WpfApp1.ModelView;

namespace WpfApp1.Models
{
    public class EmployeeService
    {

        public static ObservableCollection<Employee>? e;//list to store employee details
        private string invMess;
        string path = @"C:\Users\manoj\OneDrive\Desktop\employee.txt";

        #region constructor 
        public EmployeeService()
        {
            e = new ObservableCollection<Employee>()
            {
                new Employee{Name="Manoj" , Age=21,Id=001 },
                new Employee{Name="Manoj1" , Age=21,Id=002 }
            };

        }
        #endregion

        #region getEmployee
        public ObservableCollection<Employee> GetEmployees()//Getting employees list
        {

            return e;
        }

        #endregion

        #region Addemployee
        public bool AddEmployee(Employee en)//Adding Employee
        {
            //bool cond = false;
            
            //if (en.Age>=18 && en.Age<60 && !string.IsNullOrEmpty(en.Name.Trim()))
            //{
            //    e.Add(en);
            //    cond = true;
            //    //File.WriteAllText(path, en.Name); ;

            //}
            //else if(en.Id==0)
            //{
            //    invMess = "Invalid ID";

            //    MessageBox.Show(invMess, "ERROR");
            //}

            //else if (en.Age < 18|| string.IsNullOrEmpty(en.Name))
            //{
            //    invMess = "Invalid Name/Age(>18,<60)/ID/Format";

            //    MessageBox.Show(invMess,"ERROR");

            //}
            //return cond;

            bool cond = false;
            int flag = 0;
            
            if (en.Id == 0)
            {
                MessageBoxResult result = MessageBox.Show("ID cant be Zero", "Error");
                throw new ArgumentException("Invalid ID.....!!");
            }


            else if (en.Age <= 18 || en.Age >= 60)
            {
                MessageBoxResult result = MessageBox.Show("Invalid Age!(should be >18 and <60", "Error");
                throw new ArgumentException("Invalid Age Limit for the Employee!");
            }
            if (en.Id != 0)
            {
                for (int i = 0; i < e.Count; i++)
                {
                    if (en.Id == e[i].Id)
                    {
                        flag = 1;
                        MessageBoxResult result = MessageBox.Show("ID already exists!", "Error");
                        break;
                    }
                }
            }
            if (flag == 0)
            {
                e.Add(en);
                readFile(en);
                cond = true;

            }
            return cond;
        }
        #endregion

        #region writing to file
        public void readFile(Employee e1)
        {
            StreamWriter s = new StreamWriter(path, true);
            s.Write(e1.Id + " ");
            s.Write(e1.Name + " ");
            s.Write(e1.Age + " ," + "\n");
            s.Dispose();
            s.Close();
        }
        #endregion

        #region deleting file
        public void deleteLine(int l)
        {
            string line = string.Empty;
            string line_to_delete = l.ToString();

            using (StreamReader reader = new StreamReader(@"C:\Users\manoj\OneDrive\Desktop\employee.txt"))
            {
                using (StreamWriter writer = new StreamWriter(@"C:\Users\manoj\OneDrive\Desktop\employee.txt"))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (String.Contains(line.ToString, line_to_delete.ToString)==true)
                            continue;

                        writer.WriteLine(line);
                    }
                    writer.Close();
                }
                reader.Close();
            }
            //using (FileStream file = new FileStream(@"C:\Users\manoj\OneDrive\Desktop\employee.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{
            //    using (StreamReader sr = new StreamReader(@"C:\Users\manoj\OneDrive\Desktop\employee.txt"))
            //    {
            //        using (StreamWriter writer = new StreamWriter(@"C:\Users\manoj\OneDrive\Desktop\employee.txt"))
            //        {
            //            while ((line = sr.ReadLine()) != null)
            //            {
            //                if (String.Compare(line, line_to_delete) == 0)
            //                    continue;

            //                writer.WriteLine(line);
            //            }
            //        }
            //    }
            //}
        }

       
        #endregion

        #region exp
        private Exception ArgumentException(string v)
        {
            throw new NotImplementedException();
        }
        #endregion
        
        #region delete
        public bool RemoveEmployee(int id) 
        {
            bool deleted = false;
            for(int i=0; i < e.Count;i++)
            {
                if (e[i].Id == id)
                {
                    e.RemoveAt(i);
                    try
                    {
                        deleteLine(id);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); continue; }
                    deleted = true;
                    break;
                }
            }
            
            return deleted;
        }
        #endregion

        #region update
        public bool UpdateEmployee(Employee ed)
        {
            bool Update = false;

            for(int i=0;i<e.Count;i++)
            {
                if (e[i].Id==ed.Id)
                {
                    e[i].Name = ed.Name;
                    e[i].Age = ed.Age;
                    Update = true;
                    break;
                }
            }
            return Update;
        }
        #endregion

        #region search
        public Employee searchEmployee(int id)
        {
            
                return e.FirstOrDefault(e => e.Id == id);//Else we can use this single statement
        }
        #endregion

        
    }

}
