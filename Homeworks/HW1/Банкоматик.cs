using System;
using System.Collections.Generic;

public class Program
	{
		static void PrintBalance(int balance, string cur = "₽")
		{
			Console.WriteLine($"Баланс: {balance}{cur}");
		}

		static void PrintHistory(List<string> history)
		{
			for(int i = 0; i<history.Count; i++){
						Console.WriteLine(history[i]);
					}
		}

		static int Deposit(int balance, List<string> history)
		{
			Console.WriteLine("Введите сумму для пополнения");
			int sum = int.Parse(Console.ReadLine());
			if (sum>0){
				balance+=sum;
				history.Add($"Пополнение: {sum} ₽");
			}
			else{
				Console.WriteLine("Сумма должна быть больше нуля");
			}

			return balance;
		}

		static int Withdraw(int balance, List<string> history){
			Console.WriteLine("Введите сумму для снятия");
			int sum = int.Parse(Console.ReadLine());
			if(sum>0 && sum<=balance){
				balance-=sum;
				history.Add($"Снятие: {sum} ₽");
			}
			else{
				Console.WriteLine("Сумма должна быть больше нуля и не больше баланса");
			}
			return balance;
		}







		public static void Main(string[] args)
		{
			Console.WriteLine("Введите начальный баланс:"); 
			int a = int.Parse(Console.ReadLine()); 
			PrintBalance(a);

			int choice = 5;

			List<string> history = new List<string>();

			while (choice!=0){
				Console.WriteLine("1 - Показать баланс \n2 - Пополнить счёт \n3 - Снять деньги \n4 - Показать историю операций \n0 - Выйти");
				choice = int.Parse(Console.ReadLine());

				if(choice==1){
					PrintBalance(a);
				}
				
				else if (choice == 2)
				{
					a = Deposit(a, history);
				}

				else if (choice == 3){
					a = Withdraw(a, history);
				}

				else if (choice == 4){
					PrintHistory(history);
				}





			}


			}
			
			 



		}

