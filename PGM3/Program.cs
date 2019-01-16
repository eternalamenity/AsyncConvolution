using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PGM3
{
    class Program
    {
        static void Main(string[] args)
        {
            nonAsyncMethod();
            asyncConvolution200Times().Wait();

            Console.ReadKey();
        }

        static void nonAsyncMethod()
        {
            MyImage image = new MyImage(1024, 1024);
            MyImage im = new MyImage(1024, 1024);
            im.CreateCheckerboard(8);


            Stopwatch zegar = new Stopwatch();
            zegar.Start();
            Console.WriteLine("Non async method");

            for (int i = 0; i < 200; i++)
            {
                syncConvolution(image, im);
                im = image;
            }
            zegar.Stop();
            Console.WriteLine(zegar.Elapsed);
            ImageManager.saveImage("C:\\Users\\etern\\Desktop\\syncConvultion.pgm", image);
        }
        

        static async Task<MyImage> asyncConvolution200Times()
        {
            MyImage image = new MyImage(1024, 1024);
            MyImage im = new MyImage(1024, 1024);
            im.CreateCheckerboard(8);
            
            Console.WriteLine("Async 2nd method");
            List<Task> tasks = new List<Task>();
            Stopwatch zegar3 = new Stopwatch();
            zegar3.Start();

            for (int i = 0; i < 200; i++)
            {
                //Divided convolution method into tasks
                tasks.Add(asyncConvolutionFirst(image, im));
                tasks.Add(asyncConvolutionThird(image, im));
                tasks.Add(asyncConvolutionFourth(image, im));
                tasks.Add(asyncConvolutionSeventh(image, im));
                tasks.Add(asyncConvolutionEight(image, im));
                tasks.Add(asyncConvolutionNinth(image, im));
                tasks.Add(asyncConvolutionTenth(image, im));
                tasks.Add(asyncConvolutionEleventh(image, im));
                tasks.Add(asyncConvolutionTwelfth(image, im));
                tasks.Add(asyncConvolutionThirtheenth(image, im));
                tasks.Add(asyncConvolutionFourteehnth(image, im));
                tasks.Add(asyncConvolutionFiftheenth(image, im));
                tasks.Add(asyncConvolutionSixtheenth(image, im));
                tasks.Add(asyncConvolutionSeventeenth(image, im));
                tasks.Add(asyncConvolutionEighteenth(image, im));
                tasks.Add(asyncConvolutionNineteenth(image, im));
                tasks.Add(asyncConvolutionTwentyth(image, im));
                tasks.Add(asyncConvolutionTwentythOne(image, im));
                
                await Task.WhenAll(tasks);
                tasks.Clear();

                im = image;
            }

            zegar3.Stop();
            Console.WriteLine(zegar3.Elapsed);
            ImageManager.saveImage("C:\\Users\\etern\\Desktop\\asyncConvultion.pgm", image);
            return im;
        }
        

        public async static Task asyncConvolutionFirst(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                //for (int i = 1; i < newImage.Size[0] / 4 - 1; i++)
                Parallel.For(1, newImage.Size[0] / 4 - 1, i =>
                {
                    for (int j = 1; j < newImage.Size[1] / 4 - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
            //Console.WriteLine("First loop time : " + zegar.Elapsed);
        }

        public async static Task asyncConvolutionSeventh(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                //for (int i = 1; i < newImage.Size[0] / 4 - 1; i++)
                Parallel.For(1, newImage.Size[0] / 4 - 1, i =>
                {
                    for (int j = newImage.Size[0] / 4 - 1; j < newImage.Size[1] * 2 / 4 - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionEight(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                //for (int i = 1; i < (newImage.Size[0]) / 4 - 1; i++)
                Parallel.For(1, newImage.Size[0] / 4 - 1, i =>
                {
                    for (int j = (newImage.Size[0]) * 2 / 4 - 1; j < (newImage.Size[1]) * 3 / 4 - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionNinth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For(1, newImage.Size[0] / 4 - 1, i =>
                {
                    for (int j = (newImage.Size[0]) * 3 / 4 - 1; j < newImage.Size[1] - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }


        public async static Task asyncConvolutionTenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) / 4, (newImage.Size[0] - 1) * 2 / 4, i =>
                {
                    for (int j = 1; j < (newImage.Size[1] - 1) / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionEleventh(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) / 4, (newImage.Size[0] - 1) * 2 / 4, i =>
                {
                    for (int j = (newImage.Size[1] - 1) / 4; j < (newImage.Size[1] - 1) * 2 / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionTwelfth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) / 4, (newImage.Size[0] - 1) * 2 / 4, i =>
                {
                    for (int j = (newImage.Size[1] - 1) * 2 / 4; j < (newImage.Size[1] - 1) * 3 / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionThirtheenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) / 4, (newImage.Size[0] - 1) * 2 / 4, i =>
                {
                    for (int j = (newImage.Size[1] - 1) * 3 / 4; j < newImage.Size[1] - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }


        public async static Task asyncConvolutionFourteehnth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 2 / 4, (newImage.Size[0] - 1) * 3 / 4, i =>
                {
                    for (int j = 1; j < (newImage.Size[1] - 1) / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }


        public async static Task asyncConvolutionFiftheenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 2 / 4, (newImage.Size[0] - 1) * 3 / 4, i =>
                {
                    for (int j = (newImage.Size[1] - 1) / 4; j < (newImage.Size[1] - 1) * 2 / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionSixtheenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 2 / 4, (newImage.Size[0] - 1) * 3 / 4, i =>
                {
                    for (int j = (newImage.Size[1] - 1) * 2 / 4; j < (newImage.Size[1] - 1) * 3 / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionSeventeenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 2 / 4, (newImage.Size[0] - 1) * 3 / 4, i =>
                {
                    for (int j = (newImage.Size[1] - 1) * 3 / 4; j < newImage.Size[1] - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }


        public async static Task asyncConvolutionEighteenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 3 / 4, newImage.Size[0] - 1, i =>
                {
                    for (int j = 1; j < (newImage.Size[1] - 1) / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionNineteenth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 3 / 4, newImage.Size[0] - 1, i =>
                {
                    for (int j = (newImage.Size[1] - 1) / 4; j < (newImage.Size[1] - 1) * 2 / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionTwentyth(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 3 / 4, newImage.Size[0] - 1, i =>
                {
                    for (int j = (newImage.Size[1] - 1) * 2 / 4; j < (newImage.Size[1] - 1) * 3 / 4; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }

        public async static Task asyncConvolutionTwentythOne(MyImage newImage, MyImage oldImage)
        {
            await Task.Factory.StartNew(() =>
            {
                Parallel.For((newImage.Size[0] - 1) * 3 / 4, newImage.Size[0] - 1, i =>
                {
                    for (int j = (newImage.Size[1] - 1) * 3 / 4; j < newImage.Size[1] - 1; j++)
                    {
                        int index = i * oldImage.Size[1] + j;
                        newImage.Values[index] =
                            oldImage.Values[index] * 0.6f +
                            oldImage.Values[index + 1] * 0.1f +
                            oldImage.Values[index - 1] * 0.1f +
                            oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                            oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                    }
                });
            });
        }
        

        
        public async static Task asyncConvolutionThird(MyImage newImage, MyImage oldImage)
        {
            await Task.Run(() =>
            {
                //dla górnej linii
                for (int j = 1; j < newImage.Size[1] - 1; j++)
                {
                    int i = 0;
                    int index = i * newImage.Size[1] + j;
                    newImage.Values[index] =
                        oldImage.Values[index] * 0.6f +
                        oldImage.Values[index - 1] * 0.1f +
                        oldImage.Values[index + 1] * 0.1f +
                        oldImage.Values[index + oldImage.Size[0]] * 0.1f;
                }

                //dla dolnej linii
                for (int j = 1; j < oldImage.Size[1] - 1; j++)
                {
                    int i = 1023;
                    int index = i * oldImage.Size[1] + j;
                    newImage.Values[index] =
                        oldImage.Values[index] * 0.6f +
                        oldImage.Values[index - 1] * 0.1f +
                        oldImage.Values[index + 1] * 0.1f +
                        oldImage.Values[index - oldImage.Size[0]] * 0.1f;
                }
            });
        }
        public async static Task asyncConvolutionFourth(MyImage newImage, MyImage oldImage)
        {
            await Task.Run(() =>
            {
                //dla prawej linii
                for (int i = 1; i < newImage.Size[0] - 1; i++)
                {
                    int j = 1023;
                    int index = i * newImage.Size[1] + j;
                    newImage.Values[index] =
                        oldImage.Values[index] * 0.6f +
                        oldImage.Values[index - oldImage.Size[0]] * 0.1f +
                        oldImage.Values[index + oldImage.Size[0]] * 0.1f +
                        oldImage.Values[index - 1] * 0.1f;
                }

                //dla lewej linii
                for (int i = 1; i < newImage.Size[0] - 1; i++)
                {
                    int j = 0;
                    int index = i * newImage.Size[1] + j;
                    newImage.Values[index] =
                        oldImage.Values[index] * 0.6f +
                        oldImage.Values[index - oldImage.Size[0]] * 0.1f +
                        oldImage.Values[index + oldImage.Size[0]] * 0.1f +
                        oldImage.Values[index + 1] * 0.1f;
                }


                //górny lewy róg
                newImage.Values[0] =
                    oldImage.Values[0] * 0.6f +
                    oldImage.Values[0 + 1] * 0.1f +
                    oldImage.Values[0 + oldImage.Size[0]] * 0.1f;

                //górny prawy róg
                newImage.Values[oldImage.Size[1]] =
                    oldImage.Values[oldImage.Size[1]] * 0.6f +
                    oldImage.Values[oldImage.Size[1] - 1] * 0.1f +
                    oldImage.Values[oldImage.Size[1] + oldImage.Size[0]] * 0.1f;

                //dolny lewy róg
                newImage.Values[1023 * oldImage.Size[1]] =
                    oldImage.Values[1023 * oldImage.Size[1]] * 0.6f +
                    oldImage.Values[1023 * oldImage.Size[1] + 1] * 0.1f +
                    oldImage.Values[1023 * oldImage.Size[1] - oldImage.Size[0]] * 0.1f;

                //dolny prawy róg
                newImage.Values[1023 * oldImage.Size[1] + 1023] =
                    oldImage.Values[1023 * oldImage.Size[1] + 1023] * 0.6f +
                    oldImage.Values[1023 * oldImage.Size[1] + 1023 - 1] * 0.1f +
                    oldImage.Values[1023 * oldImage.Size[1] + 1023 - oldImage.Size[1]] * 0.1f;

            });
        }


        public static void syncConvolution(MyImage newImage, MyImage oldImage)
        {
            for (int i = 1; i < newImage.Size[0] - 1; i++)
            {
                for (int j = 1; j < newImage.Size[1] - 1; j++)
                {
                    int index = i * oldImage.Size[1] + j;
                    newImage.Values[index] =
                        oldImage.Values[index] * 0.6f +
                        oldImage.Values[index + 1] * 0.1f +
                        oldImage.Values[index - 1] * 0.1f +
                        oldImage.Values[index + oldImage.Size[1]] * 0.1f +
                        oldImage.Values[index - oldImage.Size[1]] * 0.1f;
                }
            }

            //dla górnej linii
            for (int j = 1; j < oldImage.Size[1] - 1; j++)
            {
                int i = 0;
                int index = i * oldImage.Size[1] + j;
                newImage.Values[index] =
                    oldImage.Values[index] * 0.6f +
                    oldImage.Values[index - 1] * 0.1f +
                    oldImage.Values[index + 1] * 0.1f +
                    oldImage.Values[index + oldImage.Size[0]] * 0.1f;
            }

            //dla dolnej linii
            for (int j = 1; j < oldImage.Size[1] - 1; j++)
            {
                int i = 1023;
                int index = i * oldImage.Size[1] + j;
                newImage.Values[index] =
                    oldImage.Values[index] * 0.6f +
                    oldImage.Values[index - 1] * 0.1f +
                    oldImage.Values[index + 1] * 0.1f +
                    oldImage.Values[index - oldImage.Size[0]] * 0.1f;
            }

            //dla prawej linii
            for (int i = 1; i < oldImage.Size[0] - 1; i++)
            {
                int j = 1023;
                int index = i * oldImage.Size[1] + j;
                newImage.Values[index] =
                    oldImage.Values[index] * 0.6f +
                    oldImage.Values[index - oldImage.Size[0]] * 0.1f +
                    oldImage.Values[index + oldImage.Size[0]] * 0.1f +
                    oldImage.Values[index - 1] * 0.1f;
            }

            //dla lewej linii
            for (int i = 1; i < oldImage.Size[0] - 1; i++)
            {
                int j = 0;
                int index = i * oldImage.Size[1] + j;
                newImage.Values[index] =
                    oldImage.Values[index] * 0.6f +
                    oldImage.Values[index - oldImage.Size[0]] * 0.1f +
                    oldImage.Values[index + oldImage.Size[0]] * 0.1f +
                    oldImage.Values[index + 1] * 0.1f;
            }


            //górny lewy róg
            newImage.Values[0] =
                oldImage.Values[0] * 0.6f +
                oldImage.Values[0 + 1] * 0.1f +
                oldImage.Values[0 + oldImage.Size[0]] * 0.1f;

            //górny prawy róg
            newImage.Values[oldImage.Size[1]] =
                oldImage.Values[oldImage.Size[1]] * 0.6f +
                oldImage.Values[oldImage.Size[1] - 1] * 0.1f +
                oldImage.Values[oldImage.Size[1] + oldImage.Size[0]] * 0.1f;

            //dolny lewy róg
            newImage.Values[1023 * oldImage.Size[1]] =
                oldImage.Values[1023 * oldImage.Size[1]] * 0.6f +
                oldImage.Values[1023 * oldImage.Size[1] + 1] * 0.1f +
                oldImage.Values[1023 * oldImage.Size[1] - oldImage.Size[0]] * 0.1f;

            //dolny prawy róg
            newImage.Values[1023 * oldImage.Size[1] + 1023] =
                oldImage.Values[1023 * oldImage.Size[1] + 1023] * 0.6f +
                oldImage.Values[1023 * oldImage.Size[1] + 1023 - 1] * 0.1f +
                oldImage.Values[1023 * oldImage.Size[1] + 1023 - oldImage.Size[1]] * 0.1f;
        }
    }
}