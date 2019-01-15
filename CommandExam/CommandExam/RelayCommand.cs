using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommandExam
{
    class RelayCommand : ICommand
    {
        #region Variables
        Func<object, bool> canExecute;
        Action<object> executeAction;
        #endregion

        #region Construction/Initialization
        public RelayCommand(Action<object> executeAction) :
       this(executeAction, null)
        {
        }

        public RelayCommand(Action<object> executeAction, Func<object, bool> canExecute)
        {
            //if (executeAction == null) throw new ArgumentNullException("Execute Action was null for ICommanding Operation.");
            //this.executeAction = executeAction;
            this.executeAction = executeAction ?? throw new
           ArgumentNullException("Execute Action was null for ICommanding Operation.");
            this.canExecute = canExecute;
        }
        #endregion

        #region ICommand Member
        //CommandManager.RequerySuggested 이벤트가 호출될 때마다 실행
        //즉 CanExecuteChanged 이벤트가 호출될 때마다 실행
        public bool CanExecute(object param)
        {
            // 사원이름을 입력하지 않으면 Add 버튼은 비활성화 된다.
            if (param?.ToString().Length == 0) return false;
            bool result = this.canExecute == null ? true :
           this.canExecute.Invoke(param);
            return result;
        }
        public void Execute(object param)
        {
            //System.Windows.MessageBox.Show(param.ToString());
            this.executeAction.Invoke(param);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }


        #endregion
    }
}
