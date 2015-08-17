using System;

namespace Influence
{
	public interface InfluencerFinder 
	{ 
		/** 
		* Given a matrix of following between N LinkedIn users (with ids from 0 to N-1): 
		* followingMatrix[i][j] == true iff user i is following user j 
		* thus followingMatrix[i][j] doesn't imply followingMatrix[j][i]. 
		* Let's also agree that followingMatrix[i][i] == false 
		* 
		* Influencer is a user who is: 
		* - followed by everyone else and 
		* - not following anyone himself 
		* 
		* This method should find an Influencer by a given matrix of following, 
		* or return -1 if there is no Influencer in this group. 
		*/ 
		int getInfluencer(bool[][] followingMatrix);
	}

	public Finder : InfluencerFinder
	{
		public int getInfluencer(bool[][] followingMatrix)
		{
			int numUsers = followingMatrix[0].length;
			int numNotFollowing = 0;
			int j = 0;
			int user;
			bool colOverflow = false;

			while(numNotFollowing < numUsers)
			{
				if(user == numUsers - 1 || colOverflow)
					return -1;

				user = j;
				numNotFollowing = 0;

				while(!followingMatrix[user][j] && numNotFollowing < numUsers)
				{
					j++;
					numNotFollowing++

					if(j >= numUsers)
					{
						j = j % numUsers;
						colOverflow = true;
					}
				}
			}

			// if here, then row user has all false... check col
			int numFollowedBy = 0;

			for(int i = 0; i < numUsers; i++)
			{
				if(i == user)
					continue;

				if(!followingMatrix[i][user])
					return -1;
			}

			return user;
		}
	}
}
