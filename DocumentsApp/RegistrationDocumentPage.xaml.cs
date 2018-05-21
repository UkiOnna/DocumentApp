using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DocumentsApp
{
    /// <summary>
    /// Логика взаимодействия для RegistrationDocumentPage.xaml
    /// </summary>
    /// 
    
    public partial class RegistrationDocumentPage : Page
    {
        private Window window;
        private User user;
        public RegistrationDocumentPage(Window window,User user)
        {
            InitializeComponent();
            this.window = window;
            this.user = user;

        }

        private void CreateDocument(object sender, RoutedEventArgs e)
        {
            using (var context = new DocumentContext())
            {
                try
                {
                    if (themeDocument.Text.ToList().Count < 2) throw new Exception("Вы неправильно заполнили форму");
                    if (typeDocument.Text.ToList().Count < 2) throw new Exception("Вы неправильно заполнили форму");


                    //User user = new User { Login = loginBox.Text, Password = passwordBox.Text };
                    Document doc = new Document { PersonId = user.PersonId, CretionDate = DateTime.Now, ReviewDate = DateTime.Now.AddDays(2), DocumentTheme = themeDocument.Text, DocumentType = typeDocument.Text };
                    context.Documents.Add(doc);
                    context.SaveChanges();
                    window.Content = new MainPage(user,window,doc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }
    }
}
