﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialMediaAPI.domain.entities;

namespace SocialMediaAPI.application.Interfaces
{
    public interface IVotesService
    {
        Task<Votes> GetVoteByIdAsync(int id);
        Task<Posts> GetPostByIdAsync(int postId); 
        Task<IEnumerable<Votes>> GetVotesByPostIdAsync(int postId);
        Task<IEnumerable<Votes>> GetVotesByUserIdAsync(int userId);
        Task<Votes> AddVoteAsync(Votes vote);
        Task<Votes> UpdateVoteAsync(Votes vote);
        Task DeleteVoteAsync(int id);
        Task<Users> GetUserByIdAsync(int userId);
        Task<Votes> GetVoteByUserAndPostAsync(int userId, int postId);
        Task UpdatePostAsync(Posts post);


    }
}
