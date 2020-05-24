using System.Text;

namespace Derevia
{
    internal class DST
    {
        public Node3 root { get; set; }

        public Node3 current { get; set; }
        public DST()
        {
            root = null;
            current = null;
        }
        public void Insert3(string keyword)

        {

            Node3 newNode = new Node3
            {
                Key = keyword
            };

            if (root == null)
            {
                root = newNode;
            }
            else

            {

                Node3 current = root;

                Node3 parent;

                parent = current;

                int indexBytes = 0;

                byte[] arrayBits = new byte[keyword.Length * 8];

                byte[] arrayBytes = Encoding.GetEncoding("koi8-r").GetBytes(keyword);

                for (indexBytes = 0; indexBytes < arrayBytes.Length; indexBytes++)

                {

                    arrayBits[indexBytes * 8] = (byte)((arrayBytes[indexBytes] >> 7) & 0x01);

                    arrayBits[indexBytes * 8 + 1] = (byte)((arrayBytes[indexBytes] >> 6) & 0x01);

                    arrayBits[indexBytes * 8 + 2] = (byte)((arrayBytes[indexBytes] >> 5) & 0x01);

                    arrayBits[indexBytes * 8 + 3] = (byte)((arrayBytes[indexBytes] >> 4) & 0x01);

                    arrayBits[indexBytes * 8 + 4] = (byte)((arrayBytes[indexBytes] >> 3) & 0x01);

                    arrayBits[indexBytes * 8 + 5] = (byte)((arrayBytes[indexBytes] >> 2) & 0x01);

                    arrayBits[indexBytes * 8 + 6] = (byte)((arrayBytes[indexBytes] >> 1) & 0x01);

                    arrayBits[indexBytes * 8 + 7] = (byte)(arrayBytes[indexBytes] & 0x01);

                }

                for (int n = 3; n < arrayBits.Length; n++)

                {

                    parent = current;

                    if (current.Key == keyword)
                    {
                        break;
                    }
                    else

                    {

                        if (arrayBits[n] == 0)

                        {

                            current = current.Left;

                            if (current == null)

                            {

                                parent.Left = newNode;

                                parent.Left.Key = keyword;

                                break;

                            }

                            else if (current != null)
                            {
                                continue;
                            }
                            else if (current.Key == keyword)
                            {
                                break;
                            }
                        }

                        else if (arrayBits[n] == 1)

                        {

                            current = current.Right;

                            if (current == null)

                            {

                                parent.Right = newNode;

                                parent.Right.Key = keyword;

                                break;

                            }

                            else if (current != null)
                            {
                                continue;
                            }
                            else if (current.Key == keyword)
                            {
                                break;
                            }
                        }

                    }

                }


            }

        }
        public int Search3(string keyword)

        {

            Node3 current = root;

            if (current != null)

            {

                if (current.Key == keyword)
                {
                    return 1;
                }
                else

                {

                    int indexBytes = 0;

                    byte[] arrayBits = new byte[keyword.Length * 8];

                    byte[] arrayBytes = Encoding.GetEncoding("koi8-r").GetBytes(keyword);

                    for (indexBytes = 0; indexBytes < arrayBytes.Length; indexBytes++)

                    {

                        arrayBits[indexBytes * 8] = (byte)((arrayBytes[indexBytes] >> 7) & 0x01);

                        arrayBits[indexBytes * 8 + 1] = (byte)((arrayBytes[indexBytes] >> 6) & 0x01);

                        arrayBits[indexBytes * 8 + 2] = (byte)((arrayBytes[indexBytes] >> 5) & 0x01);

                        arrayBits[indexBytes * 8 + 3] = (byte)((arrayBytes[indexBytes] >> 4) & 0x01);

                        arrayBits[indexBytes * 8 + 4] = (byte)((arrayBytes[indexBytes] >> 3) & 0x01);

                        arrayBits[indexBytes * 8 + 5] = (byte)((arrayBytes[indexBytes] >> 2) & 0x01);

                        arrayBits[indexBytes * 8 + 6] = (byte)((arrayBytes[indexBytes] >> 1) & 0x01);

                        arrayBits[indexBytes * 8 + 7] = (byte)(arrayBytes[indexBytes] & 0x01);

                    }

                    for (int n = 3; n < arrayBits.Length; n++)

                    {

                        if (arrayBits[n] == 0)

                        {

                            current = current.Left;

                            if (current != null)

                            {

                                if (current.Key == keyword)
                                {
                                    return 1;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            else
                            {
                                return 0;
                            }
                        }

                        else if (arrayBits[n] == 1)

                        {

                            current = current.Right;

                            if (current != null)

                            {

                                if (current.Key == keyword)
                                {
                                    return 1;
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            else
                            {
                                return 0;
                            }
                        }

                        else
                        {
                            return 0;
                        }
                    }

                    return 0;

                }

            }

            else
            {
                return 0;
            }
        }
        public int Delete3(string delWord)

        {

            if (delWord != null)
            {

                Node3 current = root;

                if (current != null)

                {

                    if (current.Key == delWord)

                    {

                        current.Key = null;

                        return 1;

                    }

                    else

                    {

                        byte[] arrayBits = new byte[delWord.Length * 8];

                        byte[] arrayBytes = Encoding.GetEncoding("koi8-r").GetBytes(delWord);

                        for (int indexBytes = 0; indexBytes < arrayBytes.Length; indexBytes++)

                        {

                            arrayBits[indexBytes * 8] = (byte)((arrayBytes[indexBytes] >> 7) & 0x01);

                            arrayBits[indexBytes * 8 + 1] = (byte)((arrayBytes[indexBytes] >> 6) & 0x01);

                            arrayBits[indexBytes * 8 + 2] = (byte)((arrayBytes[indexBytes] >> 5) & 0x01);

                            arrayBits[indexBytes * 8 + 3] = (byte)((arrayBytes[indexBytes] >> 4) & 0x01);

                            arrayBits[indexBytes * 8 + 4] = (byte)((arrayBytes[indexBytes] >> 3) & 0x01);

                            arrayBits[indexBytes * 8 + 5] = (byte)((arrayBytes[indexBytes] >> 2) & 0x01);

                            arrayBits[indexBytes * 8 + 6] = (byte)((arrayBytes[indexBytes] >> 1) & 0x01);

                            arrayBits[indexBytes * 8 + 7] = (byte)(arrayBytes[indexBytes] & 0x01);

                        }

                        for (int n = 3; n < arrayBits.Length; n++)

                        {

                            if (arrayBits[n] == 0)

                            {

                                current = current.Left;

                                if (current != null)

                                {

                                    if (current.Key == delWord)

                                    {

                                        current.Key = null;

                                        return 1;

                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }

                                else
                                {
                                    return 0;
                                }
                            }

                            else if (arrayBits[n] == 1)

                            {

                                current = current.Right;

                                if (current != null)

                                {

                                    if (current.Key == delWord)

                                    {

                                        current.Key = null;

                                        return 1;

                                    }

                                    else
                                    {
                                        continue;
                                    }
                                }

                                else
                                {
                                    return 0;
                                }
                            }

                            else
                            {
                                return 0;
                            }
                        }

                        return 0;

                    }

                }

                else
                {
                    return 0;
                }
            }

            else
            {
                return 0;
            }
        }
    }
    public class Node3 // узел
    {
        public string Key { get; set; }
        public Node3 Left { get; set; }
        public Node3 Right { get; set; }
    }
}
