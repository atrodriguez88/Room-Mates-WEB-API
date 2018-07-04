using System.Linq;
using AutoMapper;
using RoomM.API.Controllers.Resources;
using RoomM.API.Core.Models;
using RoomM.API.Core.Models.Domain;

namespace RoomM.API.Mapping
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            // Domain to API (GET)
            CreateMap<Preferences, PreferencesResource>();
            CreateMap<ApplicationUser, ApplicationUserResource>();
            CreateMap<PropertyType, KeyValuePairResource>();
            CreateMap<RoomFeatures, KeyValuePairResource>();
            CreateMap<Ocupation, KeyValuePairResource>();
            CreateMap<PropertyFeatures, KeyValuePairResource>();
            CreateMap<PropertyRules, KeyValuePairResource>();
            CreateMap<Core.Models.Profile, ProfileResource>();
            // (GET)
            CreateMap<Room, RoomResource>()
            .ForMember(rr => rr.Rules, opt => opt.MapFrom(r => r.Rules.Select(RPR => new KeyValuePairResource { Id = RPR.PropertyRules.Id, Name = RPR.PropertyRules.Name })))
            .ForMember(rr => rr.PropertyFeatures, opt => opt.MapFrom(r => r.PropertyFeatures.Select(RPR => new KeyValuePairResource { Id = RPR.PropertyFeatures.Id, Name = RPR.PropertyFeatures.Name })))
            .ForMember(rr => rr.RoomFeatures, opt => opt.MapFrom(r => r.RoomFeatures.Select(RPR => new KeyValuePairResource { Id = RPR.RoomFeatures.Id, Name = RPR.RoomFeatures.Name })));
            // (POST, PUT)
            CreateMap<Room, SaveRoomResource>()
            .ForMember(rr => rr.Rules, opt => opt.MapFrom(r => r.Rules.Select(RPR => RPR.PropertyRulesId)))
            .ForMember(rr => rr.PropertyFeatures, opt => opt.MapFrom(r => r.PropertyFeatures.Select(RPR => RPR.PropertyFeaturesId)))
            .ForMember(rr => rr.RoomFeatures, opt => opt.MapFrom(r => r.RoomFeatures.Select(RPR => RPR.RoomFeaturesId)));


            //API to Domain (POST, PUT)
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
            CreateMap<SaveProfileResource, Core.Models.Profile>()
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
                var removedRules = r.Rules.Where(RPR => !rr.Rules.Contains(RPR.PropertyRulesId)).ToList();
                foreach (var remR in removedRules)
                    r.Rules.Remove(remR);

                // Add new Rules
                var addedRules = rr.Rules.Where(id => !r.Rules.Any(RPR => RPR.PropertyRulesId == id))
                    .Select(id => new RoomsPropertyRules { PropertyRulesId = id }).ToList();
                foreach (var ar in addedRules)
                    r.Rules.Add(ar);
            })
            .ForMember(r => r.PropertyFeatures, opt => opt.Ignore())
            .AfterMap((rr, r) =>
            {
                // Remove unselected PropertyFeatures
                var removedPropFeature = r.PropertyFeatures.Where(RPR => !rr.PropertyFeatures.Contains(RPR.PropertyFeaturesId)).ToList();
                foreach (var remR in removedPropFeature)
                    r.PropertyFeatures.Remove(remR);

                // Add new PropertyFeatures
                var addedPropRules = rr.PropertyFeatures.Where(id => !r.PropertyFeatures.Any(RPR => RPR.PropertyFeaturesId == id))
                    .Select(id => new RoomsPropertyFeatures { PropertyFeaturesId = id }).ToList();
                foreach (var aPF in addedPropRules)
                    r.PropertyFeatures.Add(aPF);
            })
            .ForMember(r => r.RoomFeatures, opt => opt.Ignore())
            .AfterMap((rr, r) =>
            {
                // Remove unselected RoomFeatures
                var removedRoomFeature = r.RoomFeatures.Where(RPR => !rr.RoomFeatures.Contains(RPR.RoomFeaturesId)).ToList();
                foreach (var remR in removedRoomFeature)
                    r.RoomFeatures.Remove(remR);

                // Add new RoomFeatures
                var addedRoomFeature = rr.RoomFeatures.Where(id => !r.RoomFeatures.Any(RPR => RPR.RoomFeaturesId == id))
                    .Select(id => new RoomRoomFeatures { RoomFeaturesId = id }).ToList();
                foreach (var aRF in addedRoomFeature)
                    r.RoomFeatures.Add(aRF);
            });

        }
    }
}