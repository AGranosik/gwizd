import {
  transition,
  trigger,
  query,
  style,
  animate,
  group,
  animateChild,
} from '@angular/animations';
import {
  reversedVerticalSlideAnimation,
  verticalSlideAnimation,
} from 'src/app/animations';

export const sectionTwoAnimation = trigger('routeAnimations', [
  transition('* => 21', reversedVerticalSlideAnimation),
  transition('* => 22', reversedVerticalSlideAnimation),
  transition('21 => *', verticalSlideAnimation),
  transition('22 => *', verticalSlideAnimation),
]);
