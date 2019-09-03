﻿using System.Threading.Tasks;
using OQ.MineBot.PluginBase.Classes.Blocks;
using OQ.MineBot.PluginBase.Classes.Entity;

namespace OQ.MineBot.PluginBase.Classes.World
{
    public interface IBlock
    {
        ushort GetId();
        byte GetMetadata();
        ILocation GetLocation();

        bool IsBotStandingOn();
        bool IsEntityStandingOn(out IEntity[] entities);

        bool IsInInteractionRange();
        FaceData[] GetVisibleFaces ();
        FaceData[] GetVisibleFacesFrom(IPosition eyePosition); // feet position + 1.62
        FaceData[] GetPlaceableFaces();
        bool IsVisible();
        bool IsVisibleFrom(IPosition eyePosition); // feet position + 1.62

        bool IsSafeToMine(bool regardOtherBots = false);
        bool IsBlockDangerous();
        bool IsSolid();
        bool IsLiquid();
        bool IsMineable();
        bool IsAir();
        bool IsTransparent();

        bool IsUndesirableForPath();

        Task Use();
        Task<IDigAction> Dig(); // "await result.DigTask" required!
        Task<IDigAction> Dig(sbyte face);
        Task<IDigAction> Dig(FaceData faceData);
        Task Hit();
        Task LookAt(FaceData faceData = null);
        Task LookAt(sbyte face);
        Task PlaceOn(FaceData faceData);
        Task PlaceOn(sbyte face);
        Task<bool> PlaceAt();
    }
}