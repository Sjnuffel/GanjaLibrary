namespace GanjaLibrary.Interfaces.Oils
{
    public interface ISolvent
    {
        /// <summary>
        /// Heat off the chemical from the Solvent
        /// </summary>
        ISolvent Heat();

        /// <summary>
        /// Print function for ISolventmix
        /// </summary>
        void Print();
    }
}