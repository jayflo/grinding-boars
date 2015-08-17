using System;
using System.Collections.Generic;

namespace SumGame
{
	static class WinComputer
	{
		static bool canIWin(int maxChoice, int winTotal)
		{
			Scenario.maxChoice = maxChoice;
			Scenario.winTotal = winTotal;

			return WinComputer.recursiveCanPlayerAWin(new Scenario(0,0));
		}

		static bool recursiveCanPlayerAWin(Scenario scenario)
		{
			if(scenario.PlayerAHasWinningChoice())
				return true;

			for(int i = 0; i <= maxChoice; i++)
			{
				if(scenario.IsInvalidChoice(i))
					continue;

				scenario.PlayerAChoose(i);

				if(scenario.PlayerBHasWinningChoice())
					return false;

				for(int j = 0; j <= maxChoice; j++)
				{
					if(scenario.IsInvalidChoice(j))
						continue;

					Scenario branch = scenario.Clone();
					branch.PlayerBChoose(j);

					if(ScenarioCache.HasDetermined(branch))
						scenario.PlayerAHasWinningStrategy |= ScenarioCache.GetOutcome(branch);
					else
						scenario.PlayerAHasWinningStrategy |= WinComputer.recursiveCanPlayerAWin(branch);
				}
			}

			ScenarioCache.Store(scenario);

			return scenario.PlayerAHasWinningStrategy;
		}
	}

	static class ScenarioCache
	{
		static Dictionary<Scenario, bool> completed;

		static ScenarioCache()
		{
			ScenarioCache.completed = new Dictionary<Scenario, bool>()
		}

		static bool HasDetermined(Scenario s)
		{
			return ScenarioCache.completed.ContainsKey(s);
		}

		static bool GetOutcome(Scenario s)
		{
			return ScenarioCache.completed[s];
		}

		static bool Store(Scenario s)
		{
			if(!ScenarioCache.completed.ContainsKey(s))
				ScenarioCache.completed.Add(s, s.PlayerAHasWinningStrategy);
		}
	}

	class Scenario
	{
		public int PlayerATotal;
		public int PlayerBTotal;
		public HashSet<int> InvalidChoices;
		public bool PlayerAHasWinningStrategy;

		private static int maxChoice;
		private static int winTotal;

		public Scenario(int a, int b, HashSet<int> h = null)
		{
			PlayerATotal = a;
			PlayerBTotal = b;
			InvalidChoices = h ?? new HashSet<int>();
			PlayerAHasWinningStrategy = false;
		}

		public Scenario Clone()
		{
			return new Scenario(PlayerATotal, PlayerBTotal, InvalidChoices);
		}

		public void PlayerAChoose(int x)
		{
			PlayerATotal += x;
			InvalidChoices.Add(x);
		}

		public void PlayerBChoose(int x)
		{
			PlayerBTotal += x;
			InvalidChoices.Add(x);
		}

		public bool PlayerAHasWinningChoice()
		{
			return PlayerHasWinningChoice(PlayerATotal);
		}

		public bool PlayerBHasWinningChoice()
		{
			return PlayerHasWinningChoice(PlayerBTotal);
		}

		public bool IsInvalidChoice(int x)
		{
			return InvalidChoices.Contains(x);
		}

		public bool PlayerHasWinningChoice(int playerTotal)
		{
			for(int i = 0; i <= Scenario.maxChoice; i++)
			{
				if(!IsInvalidChoice(i) && (playerTotal + i >= Scenario.winTotal))
					return true;
			}

			return false;
		}

		public override bool Equals(Scenario x, Scenario y)
		{
			return (x.PlayerATotal == y.PlayerATotal)
				&& (x.PlayerBTotal == y.PlayerBTotal)
				&& (x.InvalidChoices.SetEquals(y.InvalidChoices));
		}

		public override int GetHashCode()
		{
			unchecked
			{
				int hash = 17;

				hash *= 23 + PlayerATotal.GetHashCode();
				hash *= 23 + PlayerBTotal.GetHashCode();
				hash *= 23 + InvalidChoices.GetHashCode();

				return hash;
			}
		}
	}
}