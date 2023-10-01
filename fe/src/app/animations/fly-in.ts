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
  const transform = reverse
    ? 'translateX(-20px) translateY(-20px) rotateZ(-20deg)'
    : 'translateX(20px) translateY(20px) rotateZ(20deg)';
  return [
    query(
      ':enter',
      [
        style({
          transform,
          opacity: 0,
        }),
        stagger(100, [
          animate(
            '200ms',
            style({
              transform: 'none',
              opacity: 1,
            })
          ),
        ]),
      ],
      {
        optional: true,
      }
    ),
    query(
      ':leave',
      [
        animate(
          200,
          style({
            opacity: 0,
          })
        ),
      ],
      { optional: true }
    ),
  ];
};
export const flyInAnimation = getSlideAnimation();
export const reversedFlyInAnimation = getSlideAnimation(true);
