using App.Scripts.Infrastructure.SharedViews.Animator;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Scripts.Scenes.SceneWordSearch.Features.Level.View.ViewField.ViewFieldWord.Animator
{
    public abstract class AnimatorFieldWordBase : BaseAnimatorTween
    {
        public abstract Task AnimateAppearAsync(List<ViewWord> viewWords);
        public abstract Task AnimateHideAsync(List<ViewWord> viewWords);
    }
}