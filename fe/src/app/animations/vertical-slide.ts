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
  const transformIn = `${reverse ? 'translateY(100%)' : 'translateY(-100%)'}`;
  const transformOut = `${reverse ? 'translateY(-100%)' : 'translateY(100%)'}`;
  return [
    query(':enter, :leave', style(animationStyle), {
      optional: true,
    }),
    group([
      query(
        ':enter',
        [
          style({ transform: transformIn }),
          animate('0.5s ease-in-out', style({ transform: 'translateY(0%)' })),
        ],
        { optional: true }
      ),
      query(
        ':leave',
        [
          style({ transform: 'translateY(0%)' }),
          animate('0.5s ease-in-out'),
          style({ transform: transformOut }),
        ],
        { optional: true }
      ),
    ]),
  ];
};

export const verticalSlideAnimation = getSlideAnimation();
export const reversedVerticalSlideAnimation = getSlideAnimation(true);
