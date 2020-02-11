import { trigger, state, style, animate, transition, keyframes } from '@angular/animations';

export const IfSlideAnimation = trigger('if-slide', [
    transition(':enter', [
        style({ height: 0, opacity: 0, overflow: 'hidden' }),
        animate('350ms ease-in-out')
    ]),
    transition(':leave', [
        animate('350ms ease-in-out', style({ height: 0, opacity: 0, overflow: 'hidden' }))
    ])
]);