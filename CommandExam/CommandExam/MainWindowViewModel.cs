using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace CommandExam
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public Emp _SelectedEmp;
        public Emp SelectedEmp
        {
            get
            {
                return _SelectedEmp;
            }
            set
            {
                _SelectedEmp = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string Pname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(Pname));
        }

        public RelayCommand AddEmpCommand { get; set; }
        public ObservableCollection<Emp> Emps { get; set; }
        public MainWindowViewModel()
        {
            Emps = new ObservableCollection<Emp>();
            Emps.Add(new Emp { Ename = "홍길동", Job = "Salesman" });
            Emps.Add(new Emp { Ename = "김길동", Job = "Clerk" });
            Emps.Add(new Emp { Ename = "정길동", Job = "Manager" });
            Emps.Add(new Emp { Ename = "박길동", Job = "Salesman" });
            Emps.Add(new Emp { Ename = "성길동", Job = "Clerk" });

            AddEmpCommand = new RelayCommand(AddEmp, CanAddEmp);

            SelectedEmp = new Emp();
        }

        bool CanAddEmp(object param)
        {
            if (param == null || param.ToString().Length == 0)
                return false;

            Debug.WriteLine(DateTime.Now.ToString());
            return Emps.Count < 6;
        }

        public void AddEmp(object param)
        {
            if(param != null)
                Emps.Add(new Emp { Ename = param.ToString() });
        }
    }
}
