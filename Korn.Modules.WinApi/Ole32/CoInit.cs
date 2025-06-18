namespace Korn.Utils
{
    public enum CoInit : uint
    {
        Multithreaded     = 0x00, //Initializes the thread for multi-threaded object concurrency.
        ApartmentThreaded = 0x02, //Initializes the thread for apartment-threaded object concurrency
        DisableOle1dde    = 0x04, //Disables DDE for OLE1 support
        SpeedOverMemory   = 0x08, //Trade memory for speed
    }
}