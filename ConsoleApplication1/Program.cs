using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            PacketWriter pw = new PacketWriter();
            pw.Write((ushort)Headers.Domath);
            pw.Write((ushort)MathHeaders.Addition);
            pw.Write(int.Parse(Console.ReadLine()));
            pw.Write(int.Parse(Console.ReadLine()));
      


            byte[] data = pw.GetBytes();
            //simulate sending data

            PacketReader pr = new PacketReader(data);
            Headers header = (Headers)pr.ReadUInt16();

            switch (header)
            {
                case Headers.Text:
                    {
                        string text = pr.ReadString();
                        //process text
                    }
                    break;
                case Headers.Image:
                    {
                        //Image img = pr.ReadImage();

                        //process image
                    }
                    break;
                case Headers.Domath:
                    {
                        MathHeaders mathHeader = (MathHeaders)pr.ReadInt16();
                        switch (mathHeader)
                        {
                            case MathHeaders.Addition:
                                {
                                    int num1 = pr.ReadInt32();
                                    int num2 = pr.ReadInt32();
                                    int val = num1 + num2;
                                    Console.WriteLine("our Addition value is : {0} from {1} + {2}, ", val, num1, num2);

                                }
                                break;
                            case MathHeaders.Division:
                                {

                                }
                                break;
                            case MathHeaders.Multiplication:
                                {

                                }
                                break;
                            case MathHeaders.Subtraction:
                                {

                                }
                                break;
                        }
                        break;
                    {

                    }


                        //Process DoMath
                    }
                    break;
            }
        }
    }
}
