﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;


//Using C#, write a web-api method that parses a sentence and replaces each word with the following: 
//first letter, number of distinct characters between first and last character, and last letter.  For example, Patterns would become P5s.  Words are separated by spaces or non-alphabetic characters and these separators should be maintained in their original form and location in the answer.

// party applications need to be authenticated before they call the method.
//Try not to use helper methods for string manipulation, try to write your own algorithms
//Include documentation on how to call your api
//Include test cases and the results in your solution

//How to call the API
//"http://localhost:53921/api/values/here%20is%20a%20string"
//result: h2e i0s a s4ng
//"http://localhost:53921/api/values/@this%5Eis!a&Test)String("
//result: @t3s^i0s!a&T3t)S5g(



namespace TestSolution.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/str
        [HttpGet("{str}")]
        public string Get(String str)
        {
            HashSet<String> hash = new HashSet<String>();
            hash.Add("`");
            hash.Add("~");
            hash.Add("!");
            hash.Add("@"); 
            hash.Add("#");
            hash.Add("$");
            hash.Add("%");
            hash.Add("^");
            hash.Add("&");
            hash.Add("*");
            hash.Add("(");
            hash.Add(")");
            hash.Add("-");
            hash.Add("_");
            hash.Add("+");
            hash.Add("="); 
            hash.Add("{");
            hash.Add("}");
            hash.Add("'");
            hash.Add("|");
            hash.Add("?");
            hash.Add("<");
            hash.Add(">");
            hash.Add(" ");

			int strIndex = 0;
			int wordStart = 0;
			ArrayList array = new ArrayList();
			while (strIndex != str.Length)
			{
                if (hash.Contains(str.Substring(strIndex, 1)))
				{
                    array.Add(str.Substring(wordStart, strIndex - wordStart + 1));
                    wordStart = strIndex;
                    wordStart++;
				}
				strIndex++;
			}
            array.Add(str.Substring(wordStart, strIndex - wordStart));
            String newstr = "";

            HashSet<String> arrayHash = new HashSet<String>();
            for (int i = 0; i < array.Count; i++)
            {
                if (((String)array[i]).Length <= 2)
                {
                    newstr = newstr + array[i];
                }

                else if (((String)array[i]).Length == 3)
                {
                    newstr = newstr + ((String)array[i]).Substring(0, 1) + "0" + ((String)array[i]).Substring(((String)array[i]).Length - 2, 2);
                }
                else
                {
                    arrayHash.Clear();
                    for (int x = 1; x < ((String)array[i]).Length - 1; x++)
                    {
                        if (arrayHash.Contains(((String)array[i]).Substring(x, 1)) == false)
                            arrayHash.Add(((String)array[i]).Substring(x, 1));
                    }

                    newstr = newstr + ((String)array[i]).Substring(0, 1) + arrayHash.Count + ((String)array[i]).Substring(((String)array[i]).Length - 2, 2);
                }
            }

            return newstr;
		}

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
