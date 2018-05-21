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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Window window;
        private User user;
        public MainPage(User user, Window window, Document document = null)
        {
            InitializeComponent();
            this.user = user;
            this.window = window;
            if (document != null)
            {
                documentBox.Items.Add(document.DocumentTheme);
            }
            try
            {
                using (var context = new DocumentContext())
                {
                    for(int i = 0; i < context.Documents.ToList().Count; i++)
                    {
                        if (context.Documents.ToList()[i].PersonId == user.PersonId)
                        {
                            documentBox.Items.Add(context.Documents.ToList()[i].DocumentTheme);
                        }
                    }
                }
            }
            catch
            {

            }

            //появляется страница 
            //челик создает документ и хочет предложить этот документ челику другому 
            //..другой челик заходит и оп собобщение где да нет  

        }

        private void CreateDocumentPage(object sender, RoutedEventArgs e)
        {
            window.Content = new RegistrationDocumentPage(window, user);
        }
    }
}
