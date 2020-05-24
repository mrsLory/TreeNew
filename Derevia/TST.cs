namespace Derevia
{
    internal class TST
    {
        private ClassLeaf cRoot;
        private readonly char chrNull = '\0';
        private readonly bool index = true;
        private bool add = false;
        private bool poisk_chr = false;
        public TST()
        {
            cRoot = new ClassLeaf(chrNull);
        }
        public void Insert2(string str)
        {
            Insert2_insert(ref cRoot, str);
        }
        public int Search2(string str)
        {
            return Search2_search(ref cRoot, str);
        }
        public int Delete2(string str)
        {
            return Delete2_delete(ref cRoot, str);
        }
        public void Insert2_insert(ref ClassLeaf cLeaf, string strWord)
        {
            if (strWord == "")
            {
                return;
            }
            if (add == false)
            {
                cLeaf.chr = chrNull;
                add = true;
            }
            if (strWord[0] > cLeaf.chr)
            {
                if (cLeaf.down != null)
                {
                    Insert2_insert(ref cLeaf.down, strWord);
                }
                else
                {
                    ClassLeaf cDown = new ClassLeaf(strWord[0]);
                    cLeaf.down = cDown;
                    if (strWord.Length == 1)
                    {
                        Insert2_insert(ref cDown, strWord);
                        cLeaf.index = index;
                    }
                    if (strWord.Length > 1)
                    {
                        Insert2_insert(ref cDown, strWord);
                    }
                }
            }
            else if (strWord[0] < cLeaf.chr)
            {
                if (cLeaf.up != null)
                {
                    Insert2_insert(ref cLeaf.up, strWord);
                }
                else
                {
                    ClassLeaf cUp = new ClassLeaf(strWord[0]);
                    cLeaf.up = cUp;
                    if (strWord.Length == 1)
                    {
                        Insert2_insert(ref cUp, strWord);
                        cLeaf.index = index;
                    }
                    if (strWord.Length > 1)
                    {
                        Insert2_insert(ref cUp, strWord);
                    }
                }
            }
            else if (strWord[0] == cLeaf.chr)
            {
                if (strWord.Length > 1)
                {
                    if (cLeaf.next != null)
                    {
                        if (strWord.Length == 1)
                        {
                            cLeaf.index = index;
                        }

                        Insert2_insert(ref cLeaf.next, strWord.Substring(1));
                    }
                    else
                    {
                        ClassLeaf cNext = new ClassLeaf(strWord[1]);
                        cLeaf.next = cNext;

                        Insert2_insert(ref cNext, strWord.Substring(1));
                    }
                }
                if (strWord.Length == 1)
                {
                    cLeaf.index = index;
                }
            }

        }
        public int Search2_search(ref ClassLeaf cLeaf, string strWord)
        {
            if (strWord == "")
            {
                return 0;
            }
            if (poisk_chr == false)
            {
                cLeaf.chr = chrNull;
                poisk_chr = true;
            }
            int poisk = 0;
            if (cLeaf == null)
            {
                return poisk;
            }
            if (strWord[0] > cLeaf.chr)
            {
                if (cLeaf.down != null)
                {
                    return Search2_search(ref cLeaf.down, strWord);
                }
                else
                {
                    poisk_chr = false;
                    return poisk;
                }
            }
            else if (strWord[0] < cLeaf.chr)
            {
                if (cLeaf.up != null)
                {
                    return Search2_search(ref cLeaf.up, strWord);
                }
                else
                {
                    poisk_chr = false;
                    return poisk;
                }
            }
            else if (strWord[0] == cLeaf.chr)
            {
                if ((strWord.Length == 1) && (cLeaf.index == true))
                {
                    poisk_chr = false;
                    return poisk + 1;
                }
                else if ((strWord.Length == 1) && (cLeaf.index == false))
                {
                    poisk_chr = false;
                    return poisk;
                }
                else
                {
                    return Search2_search(ref cLeaf.next, strWord.Substring(1));
                }
            }
            poisk_chr = false;
            return poisk;

        }

        private bool proverka = false;
        public int Delete2_delete(ref ClassLeaf cLeaf, string strWord)
        {

            if (strWord == "")
            {
                proverka = false;
                return 0;
            }
            int delete = 0;
            if (strWord[0] == 0)
            {
                proverka = false;
                return 0;
            }
            if ((strWord != null) && (proverka == true) && (cLeaf == null))
            {
                proverka = false;
                return 0;
            }

            if (strWord[0] > cLeaf.chr)
            {
                if (cLeaf.down != null)
                {
                    proverka = true;
                    return Delete2_delete(ref cLeaf.down, strWord);
                }
                else
                {
                    proverka = false;
                    return delete;
                }

            }
            else if (strWord[0] < cLeaf.chr)
            {
                if (cLeaf.up != null)
                {
                    proverka = true;
                    return Delete2_delete(ref cLeaf.up, strWord);
                }
                else
                {
                    proverka = false;
                    return delete;
                }
            }
            else if (strWord[0] == cLeaf.chr)
            {
                if ((strWord.Length == 1) && (cLeaf.index == true))
                {
                    cLeaf.index = false;
                    return delete + 1;
                }
                else if ((strWord.Length == 1) && (cLeaf.index == false))
                {
                    proverka = false;
                    return delete;
                }
                else
                {
                    proverka = true;
                    return Delete2_delete(ref cLeaf.next, strWord.Substring(1));
                }
            }
            proverka = false;
            return delete;
        }
    }
    public class ClassLeaf
    {
        public ClassLeaf down;
        public ClassLeaf up;
        public ClassLeaf next;
        public bool index;
        public char chr;
        public ClassLeaf(char c)
        {
            chr = c;
        }
        public ClassLeaf(bool i)
        {
            index = i;
        }
    }
}




