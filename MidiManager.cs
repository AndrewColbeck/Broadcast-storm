using System;
using System.IO;
using NAudio.Midi;

namespace BroadcastStorm
{
    public class MidiManager
    {
        /// <summary>
        /// The MidiManager Class is responsible for reading any Midi File, and
        /// converting the Note Event information into text, so that Rows of Block
        /// Objects can be formed and launched in-time with Music.  The code
        /// which connects the Block Client to the text file is yet to be written,
        /// however the Class implementation of reading Midi Files is fully functional.
        /// </summary>
        
        private MidiFile _mf;
        
        public MidiManager ()
        {
            LoadAssets ();
        }
        
        private void LoadAssets()
        {
            try 
            {
                _mf = new MidiFile ("/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Broadcast_Storm_Iteration_02/Pokemon.midi");
            
            } catch (Exception e) 
            {
                Console.Error.WriteLine ("Update Midi file location: {0}", e.Message);
            }
            SaveToText (_mf);
        }
        
        private void SaveToText(MidiFile mf)
        {
            StreamWriter writer = new StreamWriter("/OneDrive/_Swinburne/_Degree/OOP/_Tasks/6-4D_and_6-5HD_Custom_Program/Broadcast_Storm_Iteration_02/Midi_Notes.txt");
            try
            {
                foreach (MidiEvent e in mf.Events[1])
                {
                    if (MidiEvent.IsNoteOn(e))
                    {
                        writer.WriteLine(e.ToString());
                    }
                }
            }
            catch (Exception e) 
            {
                Console.Error.WriteLine ("Update Text file location: {0}", e.Message);
            }
            finally
            {
                writer.Close ();
            }
        }
    }
}
