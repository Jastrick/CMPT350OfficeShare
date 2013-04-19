using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Forms; 
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Surface;
using Microsoft.Surface.Presentation;
using Microsoft.Surface.Presentation.Controls;
using Microsoft.Surface.Presentation.Input;
using Awesomium.Core;
using Awesomium.Core.Data;
using Awesomium.Windows.Controls;
using Awesomium.Windows.Data;

namespace SurfaceApplication1
{
    ///test
    /// <summary>
    /// Interaction logic for SurfaceWindow1.xaml
    /// </summary>
    public partial class SurfaceWindow1 : SurfaceWindow
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public SurfaceWindow1()
        {
            InitializeComponent();

            // Add handlers for window availability events
            AddWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Occurs when the window is about to close. 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Remove handlers for window availability events
            RemoveWindowAvailabilityHandlers();
        }

        /// <summary>
        /// Adds handlers for window availability events.
        /// </summary>
        private void AddWindowAvailabilityHandlers()
        {
            // Subscribe to surface window availability events
            ApplicationServices.WindowInteractive += OnWindowInteractive;
            ApplicationServices.WindowNoninteractive += OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable += OnWindowUnavailable;
        }

        /// <summary>
        /// Removes handlers for window availability events.
        /// </summary>
        private void RemoveWindowAvailabilityHandlers()
        {
            // Unsubscribe from surface window availability events
            ApplicationServices.WindowInteractive -= OnWindowInteractive;
            ApplicationServices.WindowNoninteractive -= OnWindowNoninteractive;
            ApplicationServices.WindowUnavailable -= OnWindowUnavailable;
        }

        /// <summary>
        /// This is called when the user can interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowInteractive(object sender, EventArgs e)
        {
            //TODO: enable audio, animations here
        }

        private void ElementMenuLeft_click(object sender, RoutedEventArgs e)
        {
            ScatterViewItem svi = new ScatterViewItem();
            Grid addition = new Grid();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg";
            openFileDialog1.Title = "Select an Image File";
            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .JPG file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                addition.Children.Add(WindowCall(openFileDialog1.FileName));
                svi.Content = addition; //Sets the new grid as the SVI content

                ElementMenuItem check = (ElementMenuItem)sender;
                
                SVL.Items.Add(svi);

                ElementMenu menu = new ElementMenu();
                menu.ActivationHost = svi;
                menu.ActivationMode = ElementMenuActivationMode.HostInteraction;

                ElementMenuItem emi = new ElementMenuItem();
                emi.Header = "Close";
                emi.Click += new RoutedEventHandler(ElementCloseMenuItem_Click);
                emi.Icon = WindowCall(openFileDialog1.FileName); //Will have to change to seperate image when WindowCall changed to browser
                menu.Items.Add(emi);

                ElementMenuItem emi2 = new ElementMenuItem();
                emi2.Header = "Share";
                emi2.Click += new RoutedEventHandler(ElementShareRight_click);
                emi2.Uid = openFileDialog1.FileName;
                menu.Items.Add(emi2);

                menu.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                menu.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                addition.Children.Add(menu); //adds ElementMenu to the grid
            }
        }

        private void ElementMenuRight_click(object sender, RoutedEventArgs e)
        {
            ScatterViewItem svi = new ScatterViewItem();
            Grid addition = new Grid();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Files (*.jpg)|*.jpg";
            openFileDialog1.Title = "Select an Image File";
            //List<string> RightValues = new List<string>();
            // Show the Dialog.
            // If the user clicked OK in the dialog and
            // a .JPG file was selected, open it.
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                //RightValues.Add(openFileDialog1.FileName);
                addition.Children.Add(WindowCall(openFileDialog1.FileName));
                svi.Content = addition; //Sets the new grid as the SVI content

                ElementMenuItem check = (ElementMenuItem)sender;

                SVR.Items.Add(svi);

                ElementMenu menu = new ElementMenu();
                menu.ActivationHost = svi;
                menu.ActivationMode = ElementMenuActivationMode.HostInteraction;

                ElementMenuItem emi = new ElementMenuItem();
                emi.Header = "Close";
                emi.Click += new RoutedEventHandler(ElementCloseMenuItem_Click);
                menu.Items.Add(emi);

                ElementMenuItem emi2 = new ElementMenuItem();
                emi2.Header = "Share";
                emi.Icon = WindowCall(openFileDialog1.FileName); //Will have to change to seperate image when WindowCall changed to browser
                emi2.Click += new RoutedEventHandler(ElementShareLeft_click);
                emi2.Uid = openFileDialog1.FileName;
                menu.Items.Add(emi2);

                menu.VerticalAlignment = System.Windows.VerticalAlignment.Top;
                menu.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                addition.Children.Add(menu); //adds ElementMenu to the grid
            }
        }

        private void ElementShareLeft_click(object sender, RoutedEventArgs e)
        {
            ElementMenuItem check = (ElementMenuItem)sender;

            ScatterViewItem svi = new ScatterViewItem();
            String Aloha = check.Uid;
            Grid addition = new Grid();
            addition.Children.Add(WindowCall(Aloha));
            svi.Content = addition; //Sets the new grid as the SVI content

            SVL.Items.Add(svi);

            ElementMenu menu = new ElementMenu();
            menu.ActivationHost = svi;
            menu.ActivationMode = ElementMenuActivationMode.HostInteraction;
            ElementMenuItem emi = new ElementMenuItem();
            emi.Header = "Close";
            emi.Click += new RoutedEventHandler(ElementCloseMenuItem_Click);
            menu.Items.Add(emi);


            ElementMenuItem emi2 = new ElementMenuItem();
            emi2.Header = "Share";
            emi2.Click += new RoutedEventHandler(ElementShareRight_click);
            emi2.Uid = Aloha;
            emi.Icon = WindowCall(Aloha); //Will have to change to seperate image when WindowCall changed to browser
            menu.Items.Add(emi2);
            menu.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            menu.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            addition.Children.Add(menu); //adds ElementMenu to the grid
           
        }

        private void ElementShareRight_click(object sender, RoutedEventArgs e)
        {
            ElementMenuItem check = (ElementMenuItem)sender;

            ScatterViewItem svi = new ScatterViewItem();
            String Aloha = check.Uid;
            Grid addition = new Grid();
            addition.Children.Add(WindowCall(Aloha));
            svi.Content = addition; //Sets the new grid as the SVI content

            SVR.Items.Add(svi);

            ElementMenu menu = new ElementMenu();
            menu.ActivationHost = svi;
            menu.ActivationMode = ElementMenuActivationMode.HostInteraction;
            ElementMenuItem emi = new ElementMenuItem();
            emi.Header = "Close";
            emi.Click += new RoutedEventHandler(ElementCloseMenuItem_Click);
            menu.Items.Add(emi);


            ElementMenuItem emi2 = new ElementMenuItem();
            emi2.Header = "Share";
            emi2.Click += new RoutedEventHandler(ElementShareLeft_click);
            emi2.Uid = Aloha;
            emi.Icon = WindowCall(Aloha); //Will have to change to seperate image when WindowCall changed to browser
            menu.Items.Add(emi2);
            menu.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            menu.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            addition.Children.Add(menu); //adds ElementMenu to the grid
        }

        //Creates the object to be added to the window. Currently just creates a Koala image, to be replaced with browser code.
        private Image WindowCall(String yoHelloHooray) {
            //Assign the image in the Stream to the image property
            BitmapImage testImage = new BitmapImage(new Uri(yoHelloHooray)); //Change for your PC
            Image testImage2 = new Image();
            testImage2.Source = testImage;
            return testImage2;
        }

        /// <summary>
        /// This is called when the user can see but not interact with the application's window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowNoninteractive(object sender, EventArgs e)
        {
            //TODO: Disable audio here if it is enabled

            //TODO: optionally enable animations here
        }

        /// <summary>
        /// This is called when the application's window is not visible or interactive.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnWindowUnavailable(object sender, EventArgs e)
        {
            //TODO: disable audio, animations here
        }

        //Browser code
        protected void webBrower_ShowCreatedWebView(Object sender, ShowCreatedWebViewEventArgs e)
        {
            if (e.TargetURL != null)
                BuildBrowserInScatterView(e.TargetURL.ToString(), ((CustomBrowser)sender).scatter);
        }

        //Browser Code
        private void BuildBrowserInScatterView(string s, ScatterView scatterview)
        {
            ScatterViewItem svi = new ScatterViewItem();
            Grid addition = new Grid();

            CustomBrowser webBrower = new CustomBrowser();
            webBrower.scatter = scatterview;
            webBrower.Width = double.NaN; //set it for auto width
            webBrower.Height = double.NaN;
            webBrower.Source = new Uri(s);
            webBrower.ShowCreatedWebView += new ShowCreatedWebViewEventHandler(webBrower_ShowCreatedWebView);

            //newItem.Margin = new Thickness(25.0, 25.0, 25.0, 25.0);
            svi.Padding = new Thickness(25.0, 25.0, 25.0, 25.0);
            //newItem.Content = webBrower;
            WrapPanel wrap = new WrapPanel();
            wrap.Orientation = System.Windows.Controls.Orientation.Vertical;
            //wrap.Children.Add(new SurfaceTextBox());
            wrap.Children.Add(webBrower);

            addition.Children.Add(wrap);
            svi.Content = addition; //Sets the new grid as the SVI content

            //ElementMenuItem check = (ElementMenuItem)sender;

            scatterview.Items.Add(svi);

            ElementMenu menu = new ElementMenu();
            menu.ActivationHost = svi;
            menu.ActivationMode = ElementMenuActivationMode.HostInteraction;
            ElementMenuItem emi = new ElementMenuItem();
            emi.Header = "Close";
            emi.Click += new RoutedEventHandler(ElementCloseMenuItem_Click);
            menu.Items.Add(emi);

            menu.VerticalAlignment = System.Windows.VerticalAlignment.Top;
            menu.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            addition.Children.Add(menu); //adds ElementMenu to the grid
        }

        private void ElementCloseAllMenuItemsRight_Click(object sender, RoutedEventArgs e)
        {
            SVR.Items.Clear();
        }
        private void ElementCloseAllMenuItemsLeft_Click(object sender, RoutedEventArgs e)
        {
            SVL.Items.Clear();
        }

        private void ElementCloseMenuItem_Click(object sender, RoutedEventArgs e)
        {
            ScatterViewItem svi = null;
            FrameworkElement findsource = e.Source as FrameworkElement;
            while (svi == null && findsource != null)
            {
                if ((svi = findsource as ScatterViewItem) == null)
                {
                    findsource = VisualTreeHelper.GetParent(findsource) as FrameworkElement;
                }
            }
            SVL.Items.Remove(svi);
            SVR.Items.Remove(svi);
        }

        private void ElementBrowserLeft_Click(object sender, RoutedEventArgs e)
        {
            BuildBrowserInScatterView("http://www.google.com", SVL);
        }
        private void ElementBrowserRight_Click(object sender, RoutedEventArgs e)
        {
            BuildBrowserInScatterView("http://www.google.com", SVR);
        }
    }
}