import {
  transition,
  trigger,
  query,
  style,
  animate,
  group,
  animateChild,
  stagger,
} from '@angular/animations';

const getSlideAnimation = (reverse = false) => {
  return [
    transition(':enter', [
      style({
        height: 0,
      }),
      animate(
        200,
        style({
          height: '*',
        })
      ),
    ]),
    transition(':leave', [
      animate(
        100,
        style({
          height: 0,
        })
      ),
    ]),
  ];
};
export const accordionAnimation = getSlideAnimation();
export const reversedAccordionAnimation = getSlideAnimation(true);
