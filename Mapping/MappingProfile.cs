using System.Linq;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Auth;
using RoomM.API.Core.Models.Domain;
using RoomM.API.Core.QueryString;
using Profile = RoomM.API.Core.Models.Domain.Profile;

namespace RoomM.API.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Domain to API (GET)
            CreateMap<Message, MessageResource>();
            CreateMap<Photo, PhotoResource>();
            CreateMap<Preferences, PreferencesResource>();
            CreateMap<ApplicationUser, ApplicationUserResource>();
            CreateMap<PropertyType, KeyValuePairResource>();
            CreateMap<RoomFeatures, KeyValuePairResource>();
            CreateMap<Ocupation, KeyValuePairResource>();
            CreateMap<PropertyFeatures, KeyValuePairResource>();
            CreateMap<PropertyRules, KeyValuePairResource>();
            CreateMap<Profile, ProfileResource>();
            // (GET)
            CreateMap<Room, RoomResource>()
            .ForMember(rr => rr.Rules, opt => opt.MapFrom(r => r.Rules.Select(rpr => new KeyValuePairResource { Id = rpr.PropertyRules.Id, Name = rpr.PropertyRules.Name })))
            .ForMember(rr => rr.PropertyFeatures, opt => opt.MapFrom(r => r.PropertyFeatures.Select(rpr => new KeyValuePairResource { Id = rpr.PropertyFeatures.Id, Name = rpr.PropertyFeatures.Name })))
            .ForMember(rr => rr.RoomFeatures, opt => opt.MapFrom(r => r.RoomFeatures.Select(rpr => new KeyValuePairResource { Id = rpr.RoomFeatures.Id, Name = rpr.RoomFeatures.Name })));
            // (POST, PUT)
            CreateMap<Room, SaveRoomResource>()
            .ForMember(rr => rr.Rules, opt => opt.MapFrom(r => r.Rules.Select(rpr => rpr.PropertyRulesId)))
            .ForMember(rr => rr.PropertyFeatures, opt => opt.MapFrom(r => r.PropertyFeatures.Select(rpr => rpr.PropertyFeaturesId)))
            .ForMember(rr => rr.RoomFeatures, opt => opt.MapFrom(r => r.RoomFeatures.Select(rpr => rpr.RoomFeaturesId)));


            //API to Domain (POST, PUT)
            CreateMap<MessageResource, Message>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            CreateMap<ProfileQueryResource, ProfileQuery>();
            CreateMap<RoomQueryResource, RoomQuery>();
            CreateMap<SaveApplicationUserResource, ApplicationUser>();
            CreateMap<ApplicationUserResource, ApplicationUser>();
            CreateMap<PreferencesResource, Preferences>()
            .ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, PropertyType>()
            .ForMember(pt => pt.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, RoomFeatures>()
            .ForMember(r => r.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, Ocupation>()
            .ForMember(o => o.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, PropertyFeatures>()
            .ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<KeyValuePairResource, PropertyRules>()
            .ForMember(p => p.Id, opt => opt.Ignore());
            CreateMap<SaveProfileResource, Profile>()
            .ForMember(p => p.Id, opt => opt.Ignore());
            // .ForMember(p => p.Ocupation, opt => opt.MapFrom(spr => new Ocupation{Id = spr.OcupationId}));
            CreateMap<SaveRoomResource, Room>()
            .ForMember(p => p.Id, opt => opt.Ignore())
            // Many to Many(Only POST)
            // .ForMember(r => r.Rules, opt => opt.MapFrom(rr => rr.Rules.Select(id => new RoomsPropertyRules { PropertyRulesId = id })))
            // .ForMember(r => r.PropertyFeatures, opt => opt.MapFrom(rr => rr.PropertyFeatures.Select(id => new RoomsPropertyFeatures { PropertyFeaturesId = id })))
            // .ForMember(r => r.RoomFeatures, opt => opt.MapFrom(rr => rr.RoomFeatures.Select(id => new RoomRoomFeatures { RoomFeaturesId = id })))

            // Many to Many(Only PUT and PUT)
            .ForMember(r => r.Rules, opt => opt.Ignore())
            .AfterMap((rr, r) =>
            {
                // Remove unselected Rules
                var removedRules = r.Rules.Where(rpr => !rr.Rules.Contains(rpr.PropertyRulesId)).ToList();
                foreach (var remR in removedRules)
                    r.Rules.Remove(remR);

                // Add new Rules
                var addedRules = rr.Rules.Where(id => r.Rules.All(rpr => rpr.PropertyRulesId != id))
                    .Select(id => new RoomsPropertyRules { PropertyRulesId = id }).ToList();
                foreach (var ar in addedRules)
                    r.Rules.Add(ar);
            })
            .ForMember(r => r.PropertyFeatures, opt => opt.Ignore())
            .AfterMap((rr, r) =>
            {
                // Remove unselected PropertyFeatures
                var removedPropFeature = r.PropertyFeatures.Where(rpr => !rr.PropertyFeatures.Contains(rpr.PropertyFeaturesId)).ToList();
                foreach (var remR in removedPropFeature)
                    r.PropertyFeatures.Remove(remR);

                // Add new PropertyFeatures
                var addedPropRules = rr.PropertyFeatures.Where(id => r.PropertyFeatures.All(rpr => rpr.PropertyFeaturesId != id))
                    .Select(id => new RoomsPropertyFeatures { PropertyFeaturesId = id }).ToList();
                foreach (var aPf in addedPropRules)
                    r.PropertyFeatures.Add(aPf);
            })
            .ForMember(r => r.RoomFeatures, opt => opt.Ignore())
            .AfterMap((rr, r) =>
            {
                // Remove unselected RoomFeatures
                var removedRoomFeature = r.RoomFeatures.Where(rpr => !rr.RoomFeatures.Contains(rpr.RoomFeaturesId)).ToList();
                foreach (var remR in removedRoomFeature)
                    r.RoomFeatures.Remove(remR);

                // Add new RoomFeatures
                var addedRoomFeature = rr.RoomFeatures.Where(id => r.RoomFeatures.All(rpr => rpr.RoomFeaturesId != id))
                    .Select(id => new RoomRoomFeatures { RoomFeaturesId = id }).ToList();
                foreach (var aRf in addedRoomFeature)
                    r.RoomFeatures.Add(aRf);
            });

        }
    }
}