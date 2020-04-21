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
using Business;
using Entity;
namespace Semana04
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            BPedido bPedido = null;
            try
            {
                bPedido = new BPedido();
                dvgPedido.ItemsSource = bPedido.GetPedidosEntreFechas(
                Convert.ToDateTime(txtFechaInicio.Text),
                Convert.ToDateTime(txtFechaFin.Text));
            }
            catch (Exception)
            {

                MessageBox.Show("Comunicarse con el Administrador");
            }
            finally{
                bPedido = null;
            }
        }

        private void dvgPedido_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                BDetallePedido detallePedido = new BDetallePedido();
                int idPedido;
                var item = (Pedido)dvgPedido.SelectedItem;
                if (item == null) return;
                idPedido = Convert.ToInt32(item.IdPedido);
                dvgDetallePedido.ItemsSource = detallePedido.GetPedidosEntreFechas(idPedido);
                txtTotal.Text = Convert.ToString(detallePedido.GetDetalleTotalPorId(idPedido));

            }
            catch (Exception)
            {
                //throw;
            }
        }

        
    }
}
