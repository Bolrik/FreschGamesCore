using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreschGames.Core.ResourceSystem
{
    public static class Resource<T>
    {
        public static T Asset { get => Asset<T>.Instance; }
        public static T State { get => State<T>.Instance; }

        public static void UpdateAsset(T value) => Asset<T>.Assign(value);
        public static void UpdateState(T value) => State<T>.Assign(value);
    }
}
