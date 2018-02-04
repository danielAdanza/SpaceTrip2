#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("aWanHHXaDdh2q3PvYPGj9DgryAjbKL9tQ4NQjaVfEzgmY4iUvtMOCsWlio1ccmLsnbAqH4QDy7QE3I2qUNPd0uJQ09jQUNPT0mR2xFtnh1GHz2fBRpxvn8cao432rGFh2v0z6AlHrepHuK6oZs62zXpw9PmnRj68kSrWVKPIVlofFzXDWqcavbYUyjXKYELs9BnoeNDZyjzRpqC377qFQbzxWzmgrHTLC6HxCT2YKoWO21ky4lDT8OLf1Nv4VJpUJd/T09PX0tEmVXHSNoD7myQOGgCDn/voqtqrZhxDmH0ds7ewy43tMsSgXC4qma37i/dHMY3qQVJUrtQL6kfWjr3k3EJR1nAqiJhdYZ7CPlvvAh0JsCxHAos/hguN1Iw/NdDR09LT");
        private static int[] order = new int[] { 2,7,3,7,13,10,12,8,10,10,11,13,12,13,14 };
        private static int key = 210;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
