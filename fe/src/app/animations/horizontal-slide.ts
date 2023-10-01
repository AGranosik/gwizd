import {
  transition,
  trigger,
  query,
  style,
  animate,
  group,
  animateChild,
} from '@angular/animations';

const animationStyle = {
  position: 'absolute',
  top: 0,
  right: 0,
  width: '100%',
};

const getSlideAnimation = (reverse = false) => {
  const transformIn = `${reverse ? 'translateX(100%)' : 'translateX(-100%)'}`;
  const transformOut = `${reverse ? 'translateX(-100%)' : 'translateX(100%)'}`;
  return [
    query(':enter, :leave', style(animationStyle), {
      optional: true,
    }),
    group([
      query(
        ':enter',
        [
          style({ transform: transformIn }),
          animate('0.5s ease-in-out', style({ transform: 'translateX(0%)' })),
        ],
        { optional: true }
      ),
      query(
        ':leave',
        [
          style({ transform: 'translateX(0%)' }),
          animate('0.5s ease-in-out'),
          style({ transform: transformOut }),
        ],
        { optional: true }
      ),
    ]),
  ];
};

export const horizontalSlideAnimation = getSlideAnimation();
export const reversedHorizontalSlideAnimation = getSlideAnimation(true);
