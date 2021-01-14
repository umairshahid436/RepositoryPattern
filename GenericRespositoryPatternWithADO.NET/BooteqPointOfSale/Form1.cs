using BooteqPointOfSale.Business.Interfaces;
using System.Windows.Forms;

namespace BooteqPointOfSale
{
    public partial class Form1 : Form
    {
        private readonly IWorkerService _workerService;
        public Form1(IWorkerService workerService)
        {
            _workerService = workerService;
            InitializeComponent();
            _workerService.Get();
        }

    }
}
