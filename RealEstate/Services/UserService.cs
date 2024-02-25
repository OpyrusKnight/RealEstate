using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Context;
using RealEstate.Models;

namespace RealEstate.Services
{
    public class UserService
    {
        readonly RealEstateContext context;
        public UserService(RealEstateContext context)
        {
            this.context = context;
        }

        public async Task<Utilisateur> Enregistrement(Utilisateur utilisateur)
        {
            utilisateur.motpasse = Security.Hashing(utilisateur.motpasse);
            var result = await context.Utilisateurs.AddAsync(utilisateur);
            var userRegistered = result.Entity;

            await context.SaveChangesAsync();

            return userRegistered;
        }

        public Utilisateur? IsValidUserCredentials(string username, string password)
        {
            var user = context.Utilisateurs.First(u => u.nomutilisateur == username);
            if (user == null) return null;

            password = Security.Hashing(password);

            if(user.motpasse == password) return user;
            else return null;
        }
    }
}
