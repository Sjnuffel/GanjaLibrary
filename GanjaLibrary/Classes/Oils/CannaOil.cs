using GanjaLibrary.Interfaces;
using System;
using GanjaLibrary.Enums;
using GanjaLibrary.Interfaces.Oils;

namespace GanjaLibrary.Classes.Oils
{
    partial class CannaOil : ICannaOil, IChronic, ISolvent
    {
        private IChronic Chronic { get; set; }

        public event EventHandler Died;

        // Refer to IChronic's clone function
        public IChronic Clone()
        {
            return Chronic.Clone();
        }

        // Refer to IChronic's print function
        public void Print()
        {
            Chronic.Print();
        }

        // Set Stage of IChronic
        public void SetStage(Stage stage)
        {
            Chronic.SetStage(stage);
        }
    }
}
