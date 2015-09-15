using GanjaLibrary.Interfaces;
using System;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Oils;
using GanjaLibrary.Interfaces.Items;

namespace GanjaLibrary.Classes.Oils
{
    partial class CannaOil : IItem, ICannaOil, IChronic, ISolvent
    {
        private IChronic Chronic { get; set; }
        private ISolvent Solvent { get; set; }
        private IChemical Chemical { get; set; }

        public event EventHandler Died;

        // Refer to IChronics clone method
        public IChronic Clone()
        {
            return Chronic.Clone();
        }

        // Refer to IChronic's print method
        public void Print()
        {
            Chronic.Print();
        }

        // Set Stage of IChronic
        public void SetStage(Stage stage)
        {
            Chronic.SetStage(stage);
        }

        public ICannaOil CalculatePrice()
        {
            return null;
        }

    }
}
