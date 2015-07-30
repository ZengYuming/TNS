using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using TNS.Win.Util;
using TNS.Db.TestDataService;

namespace TNS.Win.View.User     
{
    public partial class Create : DevExpress.XtraEditors.XtraForm
    {
        public Create()
        {
            InitializeComponent();
        }

        private void barItemSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validate()) {
                save();
            }
        }

        private void save()
        {
            TNS.Db.Person person = new Db.Person();
            person.firstName = teFirstName.Text;
            person.secondName = teSecondName.Text;
            person.birthDay = deBirthDay.DateTime;
            person.comments = teComments.Text;

            PersonService.add(person);
        }

        private bool validate()
        {
            bool isValidated = true;
            if (teFirstName.EditValue == null && teFirstName.EditValue.ToString().Length == 0)
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("Please type first name.");
            }
            if (deBirthDay.DateTime == DateTime.MinValue)
            {
                isValidated = false;
                MessageDxUtil.ShowWarning("Please type first name.");
            }
            return isValidated;
        }
    }
}