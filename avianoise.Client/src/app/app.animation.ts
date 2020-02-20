import { trigger, style, animate, transition } from '@angular/animations';

export const IfSlideAnimation = trigger('if-slide', [
    transition(':enter', [
        style({ height: 0, opacity: 0, overflow: 'hidden' }),
        animate('350ms')
    ]),
    transition(':leave', [
        animate('350ms', style({ height: 0, opacity: 0, overflow: 'hidden' }))
    ])
]);

export const IfOpacityAnimation = trigger('if-opacity', [
    transition(':enter', [
        style({ opacity: 0, overflow: 'hidden' }),
        animate('350ms')
    ])
]);