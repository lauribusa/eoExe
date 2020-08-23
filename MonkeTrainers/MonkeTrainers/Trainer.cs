using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MonkeTrainers
{
	
	class Trainer
	{
        private readonly ITrickable Animal;

        public void Init()
		{
            Shuffle(Animal.ReturnTrickList());
        }
        
        
        #region Void func
        public void PerformTrick(int i, Action<Trick> callback)
		{
            callback(Animal.ReturnTrick(i));
		}

        void Shuffle(Trick[] tricks)
        {
            Random rand = new Random();

            for (int i = 0; i < tricks.Length - 1; i++)
            {
                int j = rand.Next(i, tricks.Length);
                Trick temp = tricks[i];
                tricks[i] = tricks[j];
                tricks[j] = temp;
            }
        }

		public Trainer(ITrickable animal)
		{
            Animal = animal;
		}
        #endregion
    }

}
