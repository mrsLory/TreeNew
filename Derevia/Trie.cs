using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Derevia
{
    public class Trie 
    {
        private Node1 root;
        public Trie()
        {
            root = getNode1();
        }

        public Node1 getNode1()
        {
            return new Node1();
        }

        public void Insert1(string key)
        {

            int length = key.Length;
            int i;
            Node1 pCrawl = root;


            // iterating from the first letter to the last letter
            for (int level = 0; level < length; level++)
            {
                i = key[level] - 'a';    
                if (i < 0)              
                    break;


                if (pCrawl.children[i] == null)
                    pCrawl.children[i] = getNode1();

                pCrawl = pCrawl.children[i];
            }
            pCrawl.isEndOfWord = true;
        }

        public int Delete1(string key)
        {

            int length = key.Length;
            int i;
            Node1 pCrawl = root;


            // iterating from the first letter to the last letter
            for (int level = 0; level < length; level++)
            {
                i = key[level] - 'a';    
                if (i < 0)              
                    break;


                if (pCrawl.children[i] == null)
                    pCrawl.children[i] = getNode1();

                pCrawl = pCrawl.children[i];
            }

            if (pCrawl.isEndOfWord != true) { return (0); }
            else { pCrawl.isEndOfWord = false; return (1); };
        }

        public int Search1(string key)
        {
            int level;
            int length = key.Length;
            int i;
            Node1 pCrawl = root;

            for (level = 0; level < length; level++)
            {
                i = key[level] - 'a';

                if (pCrawl.children[i] == null)
                    return 0;   //Absent
                pCrawl = pCrawl.children[i];
            }
            if (pCrawl != null)
            {
                if (pCrawl.isEndOfWord == true)
                    return 1;   
                return 0;       
            }
            else
                return 0;       //Absent
        }

        public class Node1
        {
            const int ALPHABET_SIZE = 26;
            // declaring 26 child nodes
            public Node1[] children = new Node1[ALPHABET_SIZE];
            // variable to check if at that node a word ends or not
            public bool isEndOfWord;
            public Node1()
            {
              
                for (int i = 0; i < ALPHABET_SIZE; i++)
                    children[i] = (null);
                   
            }
        }
    }
}
