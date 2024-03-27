using Marketplace.Application.Ad.Contracts.V1;
using Marketplace.Application.Shared.Services;
using Marketplace.Domain.Contexts.Ad.Entities;
using Marketplace.Domain.Contexts.Ad.Repositories;
using Marketplace.Domain.Contexts.Ad.ValueObjects;
using Marketplace.Domain.Shared.DomainServices;
using Marketplace.Domain.Shared.ValueObjects;
using Marketplace.Framework.Persistence;

namespace Marketplace.Application.Ad;
public class ClassifiedAdApplicationService(IClassifiedAdRepository classifiedAdRepository, IUnitOfWork unitOfWork, ICurrencyLookup currencyLookup) : IApplicationService<AdContract>
{
    private readonly IClassifiedAdRepository _classifiedAdRepository = classifiedAdRepository;
    private readonly ICurrencyLookup _currencyLookup = currencyLookup;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(AdContract command)
    {
        switch (command)
        {
            case Create cmd:
                await HandleCreate(cmd);
                break;

            case SetTitle cmd:
                await HandleUpdate(cmd.ClassifiedAdId, classifiedAd =>
                    classifiedAd.SetTitle(ClassifiedAdTitle.FromString(cmd.Title)));
                break;

            case UpdateText cmd:
                await HandleUpdate(cmd.ClassifiedAdId, classifiedAd =>
                    classifiedAd.UpdateText(ClassifiedAdText.FromString(cmd.Text)));
                break;

            case UpdatePrice cmd:
                await HandleUpdate(cmd.ClassifiedAdId, classifiedAd =>
                    classifiedAd.UpdatePrice(Money.FromDecimal(cmd.Price, cmd.CurrencyCode, _currencyLookup)));
                break;

            case RequestToPublish cmd:
                await HandleUpdate(cmd.ClassifiedAdId, classifiedAd => classifiedAd.RequestToPublish());
                break;

            case AddPicture cmd:
                await HandleUpdate(cmd.ClassifiedAdId,
                    classifiedAd => classifiedAd.AddPicture(new Uri(cmd.Url), new PictureSize(cmd.Height, cmd.Width)));
                break;
            default:
                throw new InvalidOperationException($"Command type {command.GetType().FullName} is unknown.");
        }


    }

    private async Task<ClassifiedAd> GetClassifiedAd(Guid classifiedAdId)
        => await _classifiedAdRepository.Load(new(classifiedAdId)) ?? throw new InvalidOperationException($"Classified ad ClassifiedAdId : {classifiedAdId} cannot be found");
    private async Task HandleCreate(Create cmd)
    {
        if (await _classifiedAdRepository.Exists(new(cmd.ClassifiedAdId)))
            throw new InvalidOperationException($"Classified ad ClassifiedAdId : {cmd.ClassifiedAdId} already exists");
        ClassifiedAd classifiedAd = new(new ClassifiedAdId(cmd.ClassifiedAdId), new UserId(cmd.OwnerId));
        await _classifiedAdRepository.Add(classifiedAd);
        await _unitOfWork.Commit();
    }

    private async Task HandleUpdate(Guid classifiedAdId, Action<ClassifiedAd> operation)
    {
        var classifiedAd = await GetClassifiedAd(classifiedAdId);
        operation(classifiedAd);
        await _unitOfWork.Commit();
    }
}
