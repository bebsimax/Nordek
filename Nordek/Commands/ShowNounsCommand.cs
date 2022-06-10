using Nordek.ViewModels;
using Nordek.Views;

namespace Nordek.Commands;

public class ShowNounsCommand : CommandBase
{
    private RepeatNounsViewModel _viewModel;

    public ShowNounsCommand(RepeatNounsViewModel viewModel)
    {
        _viewModel = viewModel;
    }
    public override void Execute(object parameter)
    {
        _viewModel.Artikkel = _viewModel.n.Artikkel;
        _viewModel.EntallB = _viewModel.n.EntallB;
        _viewModel.EntallU = _viewModel.n.EntallU;
        _viewModel.FlertallB = _viewModel.n.FlertallB;
        _viewModel.FlertallU = _viewModel.n.FlertallU;
    }
}