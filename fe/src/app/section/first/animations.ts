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

export const sectionFirstAnimation = trigger('routeAnimations', [
  transition('* => 1', verticalSlideAnimation),
  transition('* => 2', verticalSlideAnimation),
  transition('* => 3', verticalSlideAnimation),
  transition('1 => *', reversedVerticalSlideAnimation),
  transition('2 => *', reversedVerticalSlideAnimation),
  transition('3 => *', reversedVerticalSlideAnimation),
]);
