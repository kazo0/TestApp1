using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;

namespace TestApp1.Controls
{
	public partial class TabBarItem : TabBarItemBase
	{
		private const string SelectionIndicatorName = "SelectionIndicator";
		private const string SelectionIndicatorAnimationName = "SelectionIndicatorAnimation";
		private const string SelectionIndicatorFadeAnimationName = "SelectionIndicatorFadeAnimation";
		private const string SelectionIndicatorScaleFrameName = "SelectionIndicatorScaleFrame";
		private const string SelectionIndicatorTranslateStartFrameName = "SelectionIndicatorTranslateStartFrame";
		private const string SelectionIndicatorTranslateEndFrameName = "SelectionIndicatorTranslateEndFrame";
		private const string SelectionIndicatorTransformName = "SelectionIndicatorTransform";
		private const string SelectionIndicatorCenterStartFrameName = "SelectionIndicatorCenterStartFrame";
		private const string SelectionIndicatorCenterEndFrameName = "SelectionIndicatorCenterEndFrame";

		private UIElement _selectionIndicator;
		private EasingDoubleKeyFrame _selectionIndicatorScaleFrame;
		private Storyboard _selectionIndicatorStoryboard;
		private Storyboard _selectionIndicatorFadeStoryboard;
		private DiscreteDoubleKeyFrame _selectionIndicatorTranslateStartFrame;
		private LinearDoubleKeyFrame _selectionIndicatorTranslateEndFrame;
		private CompositeTransform _selectionIndicatorTransform;
		private DiscreteDoubleKeyFrame _selectionIndicatorCenterStartFrame;
		private LinearDoubleKeyFrame _selectionIndicatorCenterEndFrame;


		public TabBarItem()
		{
			DefaultStyleKey = typeof(TabBarItem);
		}

		public UIElement GetSelectionIndicator() => _selectionIndicator;

		protected override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			_selectionIndicator = GetTemplateChild(SelectionIndicatorName) as UIElement;
			_selectionIndicatorScaleFrame = GetTemplateChild(SelectionIndicatorScaleFrameName) as EasingDoubleKeyFrame;
			_selectionIndicatorStoryboard = GetTemplateChild(SelectionIndicatorAnimationName) as Storyboard;
			_selectionIndicatorFadeStoryboard = GetTemplateChild(SelectionIndicatorFadeAnimationName) as Storyboard;
			_selectionIndicatorTranslateStartFrame = GetTemplateChild(SelectionIndicatorTranslateStartFrameName) as DiscreteDoubleKeyFrame;
			_selectionIndicatorTranslateEndFrame = GetTemplateChild(SelectionIndicatorTranslateEndFrameName) as LinearDoubleKeyFrame;
			_selectionIndicatorTransform = GetTemplateChild(SelectionIndicatorTransformName) as CompositeTransform;
			_selectionIndicatorCenterStartFrame = GetTemplateChild(SelectionIndicatorCenterStartFrameName) as DiscreteDoubleKeyFrame;
			_selectionIndicatorCenterEndFrame = GetTemplateChild(SelectionIndicatorCenterEndFrameName) as LinearDoubleKeyFrame;

			UpdateLocalVisualState();
		}

		private void OnPropertyChanged(DependencyPropertyChangedEventArgs args)
		{
			var property = args.Property;
			if (property == IconProperty)
			{
				UpdateLocalVisualState();
			}
		}

		private void UpdateLocalVisualState()
		{
			bool shouldShowIcon = ShouldShowIcon();
			bool shouldShowContent = ShouldShowContent();

			UpdateVisualStateForIconAndContent(shouldShowIcon, shouldShowContent);
		}

		private void UpdateVisualStateForIconAndContent(bool showIcon, bool showContent)
		{
			var stateName = showIcon ? (showContent ? "IconOnTop" : "IconOnly") : "ContentOnly";
			VisualStateManager.GoToState(this, stateName, false /*useTransitions*/);
		}

		private bool ShouldShowIcon()
		{
			return Icon != null;
		}

		private bool ShouldShowContent()
		{
			return Content != null;
		}

		internal void AnimateSelectionIndicator(float from, float to, bool isOutgoing)
		{
			var size = _selectionIndicator.RenderSize;
			var scaleTo = (float)(Math.Abs(to - from) / size.Width + 1);

			_selectionIndicatorScaleFrame.Value = scaleTo;
			_selectionIndicatorTranslateStartFrame.Value = from;
			_selectionIndicatorTranslateEndFrame.Value = to;
			_selectionIndicatorCenterStartFrame.Value = (float)(from < to ? 0.0f : size.Width);
			_selectionIndicatorCenterEndFrame.Value = (float)(from < to ? size.Width : 0.0f);

			_selectionIndicatorStoryboard.Completed += (s, e) => ResetSelectionIndicator(isOutgoing ? 0f : 1f);
			_selectionIndicatorStoryboard.Begin();
		}

		internal void ResetSelectionIndicator(float desiredOpacity)
		{
			_selectionIndicator.Opacity = desiredOpacity;
			_selectionIndicatorTransform.ScaleX = 1d;
			_selectionIndicatorTransform.TranslateX = 0d;

		}
	}
}
