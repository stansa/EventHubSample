using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using Microsoft.ServiceBus.Messaging;
using System.Dynamic;

namespace RedEyeSender
{
    class Program
    {

        

        static string eventHubName = "stansevents-eh";
        static string connectionString = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Press Ctrl-C to stop the sender process");
            Console.WriteLine("Press Enter to start now");
            Console.ReadLine();
            SendingRandomMessages();
        }

        static void SendingRandomMessages()
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(connectionString, eventHubName);
           
                try
                {
                    dynamic redye = new ExpandoObject();

                    redye.has_passed = "something";
                    redye.total_no_of_cheeses = "something";
                    redye.total_batch_weight = "something";
                    redye.thread_quality = "something";
                    redye.group_55 = "something";
                    redye.fibre_mix = "something";
                    redye.L_value = "something";
                    redye.A_value = "something";
                    redye.B_value = "something";
                    redye.chroma_value = "something";
                    redye.hue_value = "something";
                    redye.delta_l = "something";
                    redye.delta_c = "something";
                    redye.delta_h = "something";
                    redye.max_colour_difference = "something";
                    redye.batch_id = "something";
                    redye.substrate_code = "something";
                    redye.count_ply = "something";
                    redye.recipe_type = "something";
                    redye.colour_category = "something";
                    redye.finish_type = "something";
                    redye.fastness_type = "something";
                    redye.dyeing_method = "something";
                    redye.Machine_volume = "something";
                    redye.material_code = "something";
                    redye.fibre_type = "something";
                    redye.dye_classes = "something";
                    redye.parent_batch_id = "something";


                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(redye);
                    //var message = Guid.NewGuid().ToString();
                    var message = json;

                    Console.WriteLine("{0} > Sending message: {1}", DateTime.Now, message);
                    eventHubClient.Send(new EventData(Encoding.UTF8.GetBytes(message)));

                    Console.WriteLine("Press Enter to end now");
                    Console.ReadLine();
            }
                catch (Exception exception)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("{0} > Exception: {1}", DateTime.Now, exception.Message);
                    Console.ResetColor();
                }

               
        
        }
    }
}
