// also exported from '@storybook/angular' if you can deal with breaking changes in 6.1
import { Story, Meta } from '@storybook/angular/types-6-0';
import {TransactionComponent} from './transaction.component';

export default {
  title: 'Shared/TransactionComponent',
  component: TransactionComponent,
  argTypes: {
  },
} as Meta;

const Template: Story<TransactionComponent> = (args: TransactionComponent) => ({
  component: TransactionComponent,
  props: args,
});

export const StateOk = Template.bind({});
StateOk.args = {
    title: 'Transferencia realizada.',
    state: 'ok'
};
export const StateSuccess = Template.bind({});
StateSuccess.args = {
    title: 'Todo salió perfecto!',
    state: 'success'
};
export const StateError = Template.bind({});
StateError.args = {
    title: 'Ha ocurrido un error.',
    state: 'error'
};