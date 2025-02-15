﻿using SocialMediaAPI.application.Interfaces;
using SocialMediaAPI.domain.entities;
using SocialMediaAPI.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialMediaAPI.infrastructure.Repositories
{
    public class VotesRepository : IVotesRepository
    {
        private readonly ApplicationDbContext _context;

        public VotesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Votes> GetVoteByIdAsync(int id)
        {
            return await _context.Votes
                .Include(v => v.Post)
                    .ThenInclude(p => p.Author) 
                .Include(v => v.Post)
                    .ThenInclude(p => p.Category) 
                .Include(v => v.User) 
                .FirstOrDefaultAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<Votes>> GetAllVotesAsync()
        {
            return await _context.Votes
                .Include(v => v.Post)
                    .ThenInclude(p => p.Author) 
                .Include(v => v.Post)
                    .ThenInclude(p => p.Category) 
                .Include(v => v.User) 
                .ToListAsync();
        }

        public async Task<IEnumerable<Votes>> GetVotesByPostIdAsync(int postId)
        {
            return await _context.Votes
                .Where(v => v.PostId == postId)
                .Include(v => v.Post)
                    .ThenInclude(p => p.Author) 
                .Include(v => v.Post)
                    .ThenInclude(p => p.Category)
                .Include(v => v.User)
                .ToListAsync();
        }

        public async Task<IEnumerable<Votes>> GetVotesByUserIdAsync(int userId)
        {
            return await _context.Votes
                .Where(v => v.UserId == userId)
                .Include(v => v.Post)
                    .ThenInclude(p => p.Author) 
                .Include(v => v.Post)
                    .ThenInclude(p => p.Category) 
                .Include(v => v.User) 
                .ToListAsync();
        }

        public async Task<Votes> AddVoteAsync(Votes vote)
        {
            await _context.Votes.AddAsync(vote);
            await _context.SaveChangesAsync();
            return vote; 
        }

        public async Task<Votes> UpdateVoteAsync(Votes vote)
        {
            _context.Votes.Update(vote);
            await _context.SaveChangesAsync();
            return vote; 
        }

        public async Task DeleteVoteAsync(int id)
        {
            var vote = await _context.Votes.FindAsync(id);
            if (vote != null)
            {
                _context.Votes.Remove(vote);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Posts> GetPostByIdAsync(int postId)
        {
            return await _context.Posts
                .FirstOrDefaultAsync(p => p.Id == postId);
        }

        public async Task<Votes> GetVoteByUserAndPostAsync(int userId, int postId)
        {
            return await _context.Votes
                .FirstOrDefaultAsync(v => v.UserId == userId && v.PostId == postId);
        }

    }
}
