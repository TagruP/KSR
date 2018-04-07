﻿namespace KSR1.Model
{
    using System;

    internal class EuclideanMetric : IMetric
    {
        public double Resemblance(string first, string second)
        {
            return 1.0d / Distance(first, second);
        }

        public double Distance(string first, string second)
        {
            ulong distance = 0;
            if (first.Length < second.Length) Swap(ref first, ref second);

            int i;

            for (i = 0; i < second.Length; i++)
            {
                distance += (ulong)((first[i] - second[i]) * (first[i] - second[i]));
            }
            for (i--; i < first.Length; i++)
            {
                distance += (ulong)Math.Pow(first[i] - 0x20, 2);
            }

            //return 1.0d / (Math.Sqrt(distance) + 1);
            return Math.Sqrt(distance);
        }

        private void Swap<T>(ref T first, ref T second)
        {
            var a = first;
            first = second;
            second = a;
        }
    }
}