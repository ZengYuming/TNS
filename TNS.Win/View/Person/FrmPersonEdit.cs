using System;
using TNS.DataService.Interface;
using TNS.Db.Mysql; 

namespace TNS.Win.View.Person
{
    public partial class FrmPersonEdit : DevExpress.XtraEditors.XtraForm
    {
        private IPersonService personService = new PersonService();

        private TNS.Db.Person person;

        public FrmPersonEdit()
        {
            InitializeComponent();
        }

        public FrmPersonEdit(TNS.Db.Person person)
        {
            this.person = person;
            InitializeComponent();
            BindData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {          
             
            this.person.firstName = textFirstName.Text;
            this.person.secondName = textSecondName.Text;
            this.person.comments = textComment.Text;
            personService.UpdatePerson(person);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void BindData()
        {
            textFirstName.Text = this.person.firstName;
            textSecondName.Text = this.person.secondName;
            textComment.Text = this.person.comments;
        }
    }
}