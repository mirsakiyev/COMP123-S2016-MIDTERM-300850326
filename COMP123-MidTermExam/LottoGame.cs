using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMP123_MidTermExam
{
    /**
     * <summary>
     * This abstract class is a blueprint for all Lotto Games
     * </summary>
     * 
     * @class LottoGame
     * @property {int} ElementNum;
     * @property {int} SetSize;
     */
    public abstract class LottoGame
    {
        // PRIVATE INSTANCE VARIABLES +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        private List<int> _elementList = new List<int>();
        private int _elementNumber;
        private List<int> _numberList = new List<int>();
        private Random _random = new Random();
        private int _setSize;

        // PUBLIC PROPERTIES ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
    * <summary>
    * This is a public property for our private _elementList field
    * </summary>
    * 
    * @property {List<int>} ElementList
    */
        public List<int> ElementList
        {
            get
            {
                return this._elementList;
            }           
        }


        /**
        * <summary>
        * This is a public property for our private _elementNumber field
        * </summary>
        * 
        * @property {int} ElementNumber
        */
        public int ElementNumber
        {
            get
            {
                return this._elementNumber;
            }

            set
            {
                this._elementNumber = value;
            }
        }


        /**
        * <summary>
        * This is a public property for our private _numberList field
        * </summary>
        * 
        * @property {List<int>} NumberList
        */
        public List<int> NumberList
        {
            get
            {
                return this._numberList;
            }           
        }


        /**
        * <summary>
        * This is a public property for our private _random field
        * </summary>
        * 
        * @property {Random} random
        */
        public Random random
        {
            get
            {
                return this._random;
            }         
        }


        /**
        * <summary>
        * This is a public property for our private _setSize field
        * </summary>
        * 
        * @property {int} SetSize
        */
        public int SetSize
        {
            get
            {
                return this._setSize;
            }

            set
            {
                this._setSize = value;
            }
        }

        // CONSTRUCTORS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * This constructor takes two parameters: elementNumber and setSize
         * The elementNumber parameter has a default value of 6
         * The setSize parameter has a default value of 49
         * </summary>
         * 
         * @constructor LottoGame
         * @param {int} elementNumber
         * @param {int} setSize
         */
        public LottoGame(int elementNumber = 6, int setSize = 49)
        {
            // assign elementNumber local variable to the ElementNumber property
            this.ElementNumber = elementNumber;

            // assign setSize local variable tot he SetSize property
            this.SetSize = setSize;

            // call the _initialize method
            this._initialize();

            // call the _build method
            this._build();
        }



        // PRIVATE METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
    * <summary>
    * This method instantiates new objects for the private fields
    * _numberList, _elementList and _random
    * </summary>
    * 
    * @private
    * @method _initialize
    * @returns {void}
    */
        private void _initialize()
        {
            this._numberList = new List<int>();
            this._elementList = new List<int>();
            this._random = new Random();
        }


        /**
 * <summary>
 * calls the inherited public
 * PickElements method and then outputs the results to the console using the overridden
 * ToString method from the abstract superclass.
 * </summary>
 * 
 * @private
 * @method _build
 * @returns {void}
 */
        private void _build()
        {
            for (int i = 0; i < SetSize; i++)
            {
                NumberList.Add(i+1);
            }
        }     
        // OVERRIDEN METHODS ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

        /**
         * <summary>
         * Override the default ToString function so that it displays the current
         * ElementList
         * </summary>
         * 
         * @override
         * @method ToString
         * @returns {string}
         */
        public override string ToString()
        {
            // create a string variable named lottoNumberString and intialize it with the empty string
            string lottoNumberString = String.Empty;

            // for each lottoNumber in ElementList, loop...
            foreach (int lottoNumber in ElementList)
            {
                // add lottoNumber and appropriate spaces to the lottoNumberString variable
                lottoNumberString += lottoNumber > 9 ? (lottoNumber + " ") : (lottoNumber + "  ");
            }

            return lottoNumberString;
        }

        // PUBLIC METHODS +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++


        public void PickElements()
        {
            if (this.ElementList.Count > 0)
            {
                ElementList.Clear();
                NumberList.Clear();
                this._build();
            }

            for (int i = 0; i <= this.ElementNumber; i++)
            {
               
                int randomIndex;
                randomIndex = this.random.Next(0, NumberList.Count);

                ElementList.Add(NumberList[randomIndex]);
                NumberList.RemoveAt(randomIndex);

                
            }

            ElementList.Sort();
          
        }
        
    }
}
