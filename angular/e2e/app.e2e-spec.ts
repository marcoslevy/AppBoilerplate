import { AppBoilerplateTemplatePage } from './app.po';

describe('AppBoilerplate App', function() {
  let page: AppBoilerplateTemplatePage;

  beforeEach(() => {
    page = new AppBoilerplateTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
