using static System.Console;

namespace PacktLibrary.Shared
{
    public interface IPlayable 
    {
         void Play();
         void Pause();
         void Stop()
         {
             WriteLine("Default implementation of Stop");
         }
    }
}